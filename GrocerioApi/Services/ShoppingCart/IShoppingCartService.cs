using GrocerioModels.Response;
using GrocerioModels.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.ShoppingCart
{
    public interface IShoppingCartService
    {
        BoolResponse AddItem(int userId, int storeProductId, int amount);
        ShoppingCartModel GetShoppingCart(int userId);
        BoolResponse RemoveItem(int cartItemId, int userId);
    }
}
