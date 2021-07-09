using GrocerioModels.Analytics.Category;
using GrocerioModels.Analytics.Product;
using GrocerioModels.Analytics.ProductType;
using GrocerioModels.Analytics.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Analytics
{
    public interface IAnalyticsService
    {
        StoreAnalytics GetStoreAnalytics(int amount);
        ProductAnalytics GetProductAnalytics(int amount);
        CategoryAnalytics GetCategoryAnalytics(int amount);
        ProductTypeAnalytics GetProductTypeAnalytics(int amount);
    }
}
