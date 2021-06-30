using GrocerioModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.ShoppingCart
{
    public interface IShoppingCartService
    {
        BoolResponse AddItem(int userId, int storeProductId, int amount);
    }
}
