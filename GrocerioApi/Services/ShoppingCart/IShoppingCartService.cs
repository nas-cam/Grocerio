using GrocerioModels.Enums.General;
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
        BoolResponse SlideCartItemAmountByOne(int cartItemId, int userId, Operation operation);
        BoolResponse SlideCartItemAmountByMultiple(int cartItemId, int userId, Operation operation, int amount);
    }
}
