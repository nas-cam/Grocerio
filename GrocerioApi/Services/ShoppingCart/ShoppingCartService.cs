using GrocerioApi.Database.Context;
using GrocerioModels.Response;
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
            var storeProduct = _context.StoreProducts.SingleOrDefault(sp => sp.Id == storeProductId);
            if(storeProduct == null)
            {
                response.Message = "Invalid stpre product id";
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
                _context.ShoppingCart.Add(new Database.Entities.ShoppingCart()
                {
                    UserId = userId,
                    StoreProductId = storeProductId,
                    Amount = amount,
                    AddedIn = Get.CurrentDate(),
                    Updated = Get.CurrentDate()
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
    }
}
