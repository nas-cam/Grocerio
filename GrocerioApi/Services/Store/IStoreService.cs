using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Store
{
    public interface IStoreService
    {
        GrocerioModels.Response.Store.InsertStoreResponse Insert(GrocerioModels.Requests.Store.InsertStoreRequest request);
        List<GrocerioModels.Product.MissingProduct> GetMissingProducts(int storeId);
    }
}
