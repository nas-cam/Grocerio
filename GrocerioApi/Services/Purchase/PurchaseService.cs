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

            return _mapper.Map<List<TrackingModel>>(_context.Trackings.Where(t => t.UserId == userId).ToList());
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
                        StreamReader locationsFile = new StreamReader("./Resources/locations.csv");
                        string line = null;
                        List<string> cityArray = new List<string>();
                        while ((line = locationsFile.ReadLine()) != null) cityArray.Add(line);

                        Random randomGenerator = new Random();
                        trackingItem.CurrentLocation = cityArray[randomGenerator.Next(cityArray.ToList().Count)];
                    }
                    _context.SaveChanges();

                    //if the amount of days i set to 0, deliver the item 
                    if (trackingItem.DaysLeft == 0)
                    {
                        _context.Purchases.Add(new Database.Entities.Purchase()
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
                            UserId = trackingItem .UserId, 
                            StoreCity = trackingItem.StoreCity, 
                            StoreImage = trackingItem.StoreImage, 
                            ProductImage = trackingItem.ProductImage, 
                            CategoryImage = trackingItem.CategoryImage
                        });
                        _context.Trackings.Remove(trackingItem);
                        _context.SaveChanges();
                        _notificationService.AddNotification($"The item: {trackingItem.Product} from {trackingItem.Store} for {trackingItem.Price} has been successfully", NotificationCategory.Success, _userService.GetAccountId(trackingItem.UserId));
                    }
                }
            }

        }

        public List<PurchaseModel> GetPurchasedItems(int userId)
        {
            var user = _context.Users.Select(x => new { Id = x.UserId, x.Active, x.Locked }).SingleOrDefault(u => u.Id == userId);
            if (user == null || !user.Active) return null;
            return _mapper.Map<List<PurchaseModel>>(_context.Purchases.Where(t => t.UserId == userId).ToList());
        }

        public BoolResponse ReturnPurchasedItem(int userId, int purchasedItemId)
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

            _context.Purchases.Remove(purchasedItem);
            _context.SaveChanges();
            response.Success = true;
            response.Message = "The item has been stored, and the refund issued successfully";

            _notificationService.AddNotification($"Tracking item: {purchasedItem.Product} from {purchasedItem.Store} for {purchasedItem.Price} returned successfully", NotificationCategory.Warning, _userService.GetAccountId(userId));


            return response;
        }
    }
}
