using AutoMapper;
using GrocerioApi.Database.Context;
using GrocerioApi.Services.Notification;
using GrocerioApi.Services.User;
using GrocerioModels.Enums.Notification;
using GrocerioModels.Purchase;
using GrocerioModels.Response;
using GrocerioModels.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        public readonly GrocerioContext _context;
        public readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;

        public PurchaseService(GrocerioContext context, IMapper mapper, INotificationService notificationService, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _notificationService = notificationService;
            _userService = userService;
        }

        public List<TrackingModel> GetTrackingItems(int userId)
        {
            var user = _context.Users.Select(x => new { Id = x.UserId, x.Active, x.Locked }).SingleOrDefault(u => u.Id == userId);
            if (user == null || !user.Active) return null;

            var dbTrackings = _context.Trackings.Include(t=>t.CreditCard).Where(t => t.UserId == userId).OrderByDescending(t => t.Purchased).ToList();
            var trackingItems = _mapper.Map<List<TrackingModel>>(dbTrackings);
            foreach (var trackingItem in trackingItems) trackingItem.CardNumber = Format.CreditCardNumber(dbTrackings.Single(t => t.Id == trackingItem.Id).CreditCard.CardNumber);

            return trackingItems;
        }

        public BoolResponse RefundTrackingItem(int userId, int trackingItemId)
        {

            var response = new BoolResponse() { Success = false };

            #region Validation 
            var user = _context.Users.Select(x => new { x.FirstName, Id = x.UserId, x.LastName, x.Address, x.Active, x.Locked }).SingleOrDefault(u => u.Id == userId);
            if (user == null)
            {
                response.Message = "Invalid user id";
                return response;
            }

            if (!user.Active)
            {
                response.Message = "The user is currently deactivated";
                return response;
            }

            var trackingItem = _context.Trackings.SingleOrDefault(t => t.Id == trackingItemId);
            if (trackingItem == null)
            {
                response.Message = "Invalid tracking item id";
                return response;
            }

            if(trackingItem.UserId != userId)
            {
                response.Message = "The tracking item does not belong to the forwarded user";
                return response;
            }
            #endregion

            #region ReturnPayment
            /*
            return the users money using the payment identifier stored with the tracking item
            handle and stop the proccess if any errors occur
            */
            #endregion

            _context.Trackings.Remove(trackingItem);
            _context.SaveChanges();
            response.Success = true;
            response.Message = "The item has been stored, and the refund issued successfully";

            _notificationService.AddNotification($"Tracking item: {trackingItem.Product} from {trackingItem.Store} for {trackingItem.Price} refunded successfully", NotificationCategory.Warning, _userService.GetAccountId(userId));

            return response;
        }

        public void MoveTrackingItems() 
        {
            //get all tracking items that need updating
            var today = Get.CurrentDate();
            var trackingItems = _context.Trackings.Include(t=>t.User).Where(t => t.LastUpdated.Date < today.Date).ToList();
            var users = _context.Users.Select(x => new { x.UserId, x.FirstName, x.LastName }).ToList();
            var trackingCities = _context.TrackingCities.Select(t => t.Name).ToList();
            if(trackingItems.Count != 0)
            {
                foreach(var trackingItem in trackingItems)
                {
                    //lower the amount of days left
                    trackingItem.DaysLeft--;
                    trackingItem.LastUpdated = today;
                    if (trackingItem.DaysLeft == 1) trackingItem.CurrentLocation = trackingItem.User.City;
                    else
                    {
                        Random randomGenerator = new Random();
                        trackingItem.CurrentLocation = trackingCities[randomGenerator.Next(trackingCities.Count)];
                    }
                    _context.SaveChanges();

                    //if the amount of days i set to 0, deliver the item 
                    if (trackingItem.DaysLeft == 0)
                    {
                        #region CreatePurchase
                        var purchase = new Database.Entities.Purchase()
                        {
                            Amount = trackingItem.Amount,
                            Category = trackingItem.Category,
                            PaymentIdentifier = trackingItem.PaymentIdentifier,
                            Price = trackingItem.Price,
                            Product = trackingItem.Product,
                            ProductDescription = trackingItem.ProductDescription,
                            ProductType = trackingItem.ProductType,
                            PurchaseDate = trackingItem.Purchased,
                            ArrivedAt = today,
                            ShippingAddress = trackingItem.ShippingAddress,
                            Store = trackingItem.Store,
                            StoreAddress = trackingItem.StoreAddress,
                            Total = trackingItem.Total,
                            UserId = trackingItem.UserId,
                            StoreCity = trackingItem.StoreCity,
                            StoreImage = trackingItem.StoreImage,
                            ProductImage = trackingItem.ProductImage,
                            CategoryImage = trackingItem.CategoryImage, 
                            CreditCardId = trackingItem.CreditCardId
                        };
                        _context.Purchases.Add(purchase);
                        _context.SaveChanges();
                        #endregion

                        #region CreateLog
                        _context.PurchaseLogs.Add(new Database.Entities.PurchaseLog()
                        {
                            Amount = trackingItem.Amount,
                            Category = trackingItem.Category,
                            PaymentIdentifier = trackingItem.PaymentIdentifier,
                            Price = trackingItem.Price,
                            Product = trackingItem.Product,
                            ProductDescription = trackingItem.ProductDescription,
                            ProductType = trackingItem.ProductType,
                            PurchaseDate = trackingItem.Purchased,
                            ArrivedAt = today,
                            ShippingAddress = trackingItem.ShippingAddress,
                            Store = trackingItem.Store,
                            StoreAddress = trackingItem.StoreAddress,
                            Total = trackingItem.Total,
                            StoreCity = trackingItem.StoreCity,
                            LogMade = today, 
                            OriginalPurchaseId = purchase.Id, 
                            Stored = false, 
                            User = users.Single(u=>u.UserId == trackingItem.UserId).FirstName+" "+ users.Single(u => u.UserId == trackingItem.UserId).LastName,
                            Message = $"The item: {trackingItem.Product} from {trackingItem.Store} for {trackingItem.Price} has been delivered successfully"
                        });
                        #endregion

                        _context.Trackings.Remove(trackingItem);
                        _context.SaveChanges();
                        _notificationService.AddNotification($"The item: {trackingItem.Product} from {trackingItem.Store} for {trackingItem.Price} has been delivered successfully", NotificationCategory.Success, _userService.GetAccountId(trackingItem.UserId));
                    }
                }
            }

        }

        public List<PurchaseModel> GetPurchasedItems(int userId)
        {
            var user = _context.Users.Select(x => new { Id = x.UserId, x.Active, x.Locked }).SingleOrDefault(u => u.Id == userId);
            if (user == null || !user.Active) return null;

            var dbPurchases = _context.Purchases.Include(p => p.CreditCard).Where(t => t.UserId == userId).OrderByDescending(p => p.PurchaseDate).ToList();
            var purchasedItems = _mapper.Map<List<PurchaseModel>>(dbPurchases);
            foreach (var purchasedItem in purchasedItems) purchasedItem.CardNumber = Format.CreditCardNumber(dbPurchases.Single(t => t.Id == purchasedItem.Id).CreditCard.CardNumber);


            return purchasedItems;
        }

        public BoolResponse ReturnPurchasedItem(int userId, int purchasedItemId, string returnReason)
        {
            var response = new BoolResponse() { Success = false };

            #region Validation 
            var user = _context.Users.Select(x => new { x.FirstName, Id = x.UserId, x.LastName, x.Address, x.Active, x.Locked }).SingleOrDefault(u => u.Id == userId);
            if (user == null)
            {
                response.Message = "Invalid user id";
                return response;
            }

            if (!user.Active)
            {
                response.Message = "The user is currently deactivated";
                return response;
            }

            var purchasedItem = _context.Purchases.SingleOrDefault(t => t.Id == purchasedItemId);
            if (purchasedItem == null)
            {
                response.Message = "Invalid purchased item id";
                return response;
            }

            if (purchasedItem.UserId != userId)
            {
                response.Message = "The item does not belong to the forwarded user";
                return response;
            }
            #endregion

            #region ReturnPayment
            /*
            return the users money using the payment identifier stored with the tracking item
            handle and stop the proccess if any errors occur
            */
            #endregion

            var historyLog = _context.PurchaseLogs.Single(h => h.OriginalPurchaseId == purchasedItem.Id);
            historyLog.Stored = true;
            historyLog.Message = returnReason;
            historyLog.LogMade = Get.CurrentDate();

            _context.Purchases.Remove(purchasedItem);
            _context.SaveChanges();
            response.Success = true;
            response.Message = "The item has been stored, and the refund issued successfully";

            _notificationService.AddNotification($"The item: {purchasedItem.Product} from {purchasedItem.Store} for {purchasedItem.Price} returned successfully", NotificationCategory.Warning, _userService.GetAccountId(userId));


            return response;
        }
    }
}
