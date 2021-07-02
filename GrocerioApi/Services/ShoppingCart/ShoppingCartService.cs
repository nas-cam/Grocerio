using GrocerioApi.Database.Context;
using GrocerioModels.Enums.General;
using GrocerioModels.Response;
using GrocerioModels.ShoppingCart;
using GrocerioModels.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        public readonly GrocerioContext _context;
        
        public ShoppingCartService(GrocerioContext context)
        {
            _context = context;
        }

        public BoolResponse AddItem(int userId, int storeProductId, int amount)
        {
            var response = new BoolResponse() { Success = false };
           
            #region Validation
            var user = _context.Users.SingleOrDefault(u => u.UserId == userId);
            if(user == null)
            {
                response.Message = "Invalid user id";
                return response;
            }

            if (!user.Active)
            {
                response.Message = "The user is currently deactivated";
                return response;
            }

            if (user.Locked)
            {
                response.Message = "The user is currently locked";
                return response;
            }
            var storeProduct = _context.StoreProducts.SingleOrDefault(sp => sp.Id == storeProductId);
            if(storeProduct == null)
            {
                response.Message = "Invalid store product id";
                return response;
            }
            if (amount == 0)
            {
                response.Message = "The amount must be greater than 0";
                return response;
            }
            #endregion

            response.Success = true;
            var existingCartEntry = _context.ShoppingCart
                                            .Include(c => c.StoreProduct)
                                            .ThenInclude(sp => sp.Product)
                                            .Include(c => c.StoreProduct)
                                            .ThenInclude(sp=>sp.Store)
                                            .Include(c => c.User)
                                            .SingleOrDefault(c => c.UserId == userId && c.StoreProductId == storeProductId);
            if (existingCartEntry == null)
            {
                Random randomGenerator = new Random();
                _context.ShoppingCart.Add(new Database.Entities.ShoppingCart()
                {
                    UserId = userId,
                    StoreProductId = storeProductId,
                    Amount = amount,
                    AddedIn = Get.CurrentDate(),
                    Updated = Get.CurrentDate(), 
                    DeliveryDays = randomGenerator.Next(1, 10)
                });

                var outputData = _context.StoreProducts
                                         .Include(sp => sp.Product)
                                         .Include(sp => sp.Store)
                                         .Select(x => new { ProductName = x.Product.Name, StoreName = x.Store.Name, x.Id })
                                         .Single(sp => sp.Id == storeProductId);

                response.Message = $"Added in {amount} of the item '{outputData.ProductName}' for the store '{outputData.StoreName}' to {user.FirstName} {user.LastName}";

            }
            else
            {
                existingCartEntry.Amount += amount;
                existingCartEntry.Updated = Get.CurrentDate();
                response.Message = $"Added in {amount} of the item '{existingCartEntry.StoreProduct.Product.Name}' for the store '{existingCartEntry.StoreProduct.Store.Name}' to {existingCartEntry.User.FirstName} {existingCartEntry.User.LastName}";
            }

            _context.SaveChanges();
            return response;
        }

        public ShoppingCartModel GetShoppingCart(int userId)
        {
            //validate user
            var user = _context.Users.Include(u => u.Account).Select(x => new { Username = x.Account.Username, Id = x.UserId, x.Active, x.Locked }).SingleOrDefault(u => u.Id == userId);
            if (user == null || !user.Active) return null;

            var response = new ShoppingCartModel() { 
                CheckoutTotal = 0, 
                Items = new List<ShoppingCartItem>()
            }; 

            var shoppingCartItems = _context.ShoppingCart
                                            .Include(c=>c.StoreProduct)
                                            .ThenInclude(sp=>sp.Product)
                                            .Include(c => c.StoreProduct)
                                            .ThenInclude(sp=>sp.Store)
                                            .Where(c => c.UserId == userId).ToList();
            if (shoppingCartItems.Count == 0) return response;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                response.Items.Add(new ShoppingCartItem()
                {
                    Store = shoppingCartItem.StoreProduct.Store.Name,
                    AddedIn = shoppingCartItem.AddedIn,
                    Amount = shoppingCartItem.Amount,
                    CartItemId = shoppingCartItem.Id,
                    Price = shoppingCartItem.StoreProduct.Price,
                    Product = shoppingCartItem.StoreProduct.Product.Name,
                    ProductId = shoppingCartItem.StoreProduct.Product.Id,
                    StoreId = shoppingCartItem.StoreProduct.Store.Id,
                    StoreProductId = shoppingCartItem.StoreProduct.Id,
                    Updated = shoppingCartItem.Updated,
                    UserId = user.Id,
                    Username = user.Username,
                    DeliveryDays = shoppingCartItem.DeliveryDays,
                    Total = Math.Round(shoppingCartItem.StoreProduct.Price * shoppingCartItem.Amount, 2)
                });
                response.CheckoutTotal += Math.Round(shoppingCartItem.StoreProduct.Price * shoppingCartItem.Amount, 2);
            }
            return response;
        }

        public BoolResponse RemoveItem(int cartItemId, int userId)
        {
            var response = new BoolResponse() { Success = false };

            #region Validation
            var user = _context.Users.Select(x => new { x.FirstName, Id = x.UserId }).SingleOrDefault(u => u.Id == userId);
            if (user == null){
                response.Message = "Invalid user id";
                return response;
            }
           
            var cartItem = _context.ShoppingCart.SingleOrDefault(c => c.Id == cartItemId);
            if(cartItem == null)
            {
                response.Message = "Invalid cart item id";
                return response;
            }

            if(cartItem.UserId != userId)
            {
                response.Message = "This cart item does not belong to the forwarded user";
                return response;
            }
            #endregion

            _context.ShoppingCart.Remove(cartItem);
            _context.SaveChanges();
            response.Success = true;
            response.Message = "Cart item removed successfully";
            return response;
        }

        public BoolResponse SlideCartItemAmountByOne(int cartItemId, int userId, Operation operation)
        {
            var response = new BoolResponse() { Success = false };

            #region Validation
            var user = _context.Users.Select(x => new { x.FirstName, Id = x.UserId, x.Active, x.Locked }).SingleOrDefault(u => u.Id == userId);
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

            if (user.Locked)
            {
                response.Message = "The user is currently locked";
                return response;
            }

            var cartItem = _context.ShoppingCart.SingleOrDefault(c => c.Id == cartItemId);
            if (cartItem == null)
            {
                response.Message = "Invalid cart item id";
                return response;
            }

            if (cartItem.UserId != userId)
            {
                response.Message = "This cart item does not belong to the forwarded user";
                return response;
            }
            #endregion

            switch (operation)
            {
                case Operation.Addition:
                    cartItem.Amount++;
                    response.Message = "Added one to the cart item";
                    break;
                case Operation.Subtraction:
                    cartItem.Amount--;
                    response.Message = "Removed one from the cart item";
                    break;
            }

            cartItem.Updated = Get.CurrentDate();
            _context.SaveChanges();
            response.Success = true;
            return response;
        }

        public BoolResponse SlideCartItemAmountByMultiple(int cartItemId, int userId, Operation operation, int amount)
        {
            var response = new BoolResponse() { Success = false };

            #region Validation
            var user = _context.Users.Select(x => new { x.FirstName, Id = x.UserId, x.Active, x.Locked }).SingleOrDefault(u => u.Id == userId);
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

            if (user.Locked)
            {
                response.Message = "The user is currently locked";
                return response;
            }

            var cartItem = _context.ShoppingCart.SingleOrDefault(c => c.Id == cartItemId);
            if (cartItem == null)
            {
                response.Message = "Invalid cart item id";
                return response;
            }

            if (cartItem.UserId != userId)
            {
                response.Message = "This cart item does not belong to the forwarded user";
                return response;
            }
            if(amount == 0)
            {
                response.Message = "The amount must be greater than 0";
                return response;
            }
            #endregion

            switch (operation)
            {
                case Operation.Addition:
                    cartItem.Amount+=amount;
                    response.Message = $"Added {amount} to the cart item";
                    break;
                case Operation.Subtraction:
                    cartItem.Amount -= amount;
                    response.Message = $"Removed {amount} from the cart item";
                    break;
            }

            cartItem.Updated = Get.CurrentDate();
            _context.SaveChanges();
            response.Success = true;
            return response;
        }

        public BoolResponse Checkout(int userId, CreditCardInformation cardInformation)
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

            if (user.Locked)
            {
                response.Message = "The user is currently locked";
                return response;
            }

            var cartItems = _context.ShoppingCart
                                    .Include(c => c.StoreProduct)
                                    .ThenInclude(sp => sp.Product)
                                    .ThenInclude(p=>p.Category)
                                    .Include(c => c.StoreProduct)
                                    .ThenInclude(sp => sp.Store)
                                    .Where(c => c.UserId == userId)
                                    .ToList();

            if(cartItems.Count == 0)
            {
                response.Message = "The user has no items in his cart";
                return response;
            }

            #endregion

            #region CardPayment
            double cartTotal = cartItems.Sum(c => Math.Round(c.StoreProduct.Price * c.Amount, 2));
            /*
            proceed to charge the users credit card, and if the payment gets processed successfully continue
            if the payment fails stop the checkout process
            after the payment, save the tracking identifier from the payment API to the database
            to be able to store and refund the payment later if needed
            */
            #endregion
                
            #region TableCheckout
            foreach (var cartItem in cartItems)
            {
                //move the cart item to the tracking table
                _context.Trackings.Add(new Database.Entities.Tracking()
                {
                    Amount = cartItem.Amount,
                    DaysLeft = cartItem.DeliveryDays,
                    LastUpdated = Get.CurrentDate(),
                    Price = cartItem.StoreProduct.Price,
                    Product = cartItem.StoreProduct.Product.Name,
                    ProductDescription = cartItem.StoreProduct.Product.Description,
                    Store = cartItem.StoreProduct.Store.Name,
                    StoreAddress = cartItem.StoreProduct.Store.Address,
                    StoreCity = cartItem.StoreProduct.Store.City,
                    CurrentLocation = cartItem.StoreProduct.Store.City,
                    ShippingAddress = user.Address,
                    Total = Math.Round(cartItem.StoreProduct.Price * cartItem.Amount, 2), 
                    Category = cartItem.StoreProduct.Product.Category.Name, 
                    ProductType = cartItem.StoreProduct.Product.ProductType.ToString(),
                    UserId = userId, 
                    Purchased = Get.CurrentDate(),
                    CategoryImage = cartItem.StoreProduct.Product.Category.ImageLink, 
                    ProductImage = cartItem.StoreProduct.Product.ImageLink, 
                    StoreImage = cartItem.StoreProduct.Store.ImageLink,
                    PaymentIdentifier ="XXXAAABBBCCC" //store the one from the payment API
                });

                //remove cart item from shopping cart table
                _context.ShoppingCart.Remove(cartItem);

                _context.SaveChanges();
            }
            #endregion

            response.Success = true;
            response.Message = $"{user.FirstName} {user.LastName}, you have checked out successfully, track your items until they arrives at your door step.";
            return response;
        }
    }
}