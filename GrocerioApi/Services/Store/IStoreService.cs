using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioModels.Filters.Store;
using GrocerioModels.Requests.Store;
using GrocerioModels.Response.Store;
using Microsoft.AspNetCore.Mvc;

namespace GrocerioApi.Services.Store
{
    public interface IStoreService
    {
        GrocerioModels.Response.Store.InsertStoreResponse Insert(GrocerioModels.Requests.Store.InsertStoreRequest request);
        List<GrocerioModels.Product.MinifiedProduct> GetMissingProducts(int storeId);
        ProductManipulationResponse AddProduct(int storeId, ProductManipulationRequest request);
        ProductManipulationResponse RemoveProduct(int storeId, ProductRemovalRequest request);
        List<GrocerioModels.Category.Category> GetStoreCategories(int storeId, bool missing);
        GrocerioModels.Store.Model.StoreModel GetStoreById(int storeId);
        List<GrocerioModels.Store.Model.StoreModel> ReceiveStores(StoreFilters storeFilters);
        List<GrocerioModels.Store.Model.StoreProductModel> ReceiveStoreProducts(ProductFilters productFilters);
    }
}
