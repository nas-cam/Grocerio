using GrocerioApi.Database.Context;
using GrocerioModels.Analytics.Category;
using GrocerioModels.Analytics.Product;
using GrocerioModels.Analytics.ProductType;
using GrocerioModels.Analytics.Store;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Analytics
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly GrocerioContext _context;

        public AnalyticsService(GrocerioContext context)
        {
            _context = context;
        }

        public StoreAnalytics GetStoreAnalytics(int amount)
        {
            var stores = _context.Stores.Select(x => new { x.Id, x.Address, x.City, x.Name, x.ImageLink }).ToList();
            var logs = _context.PurchaseLogs.ToList();
            var products = _context.Products.Include(p => p.Category).Select(x => new { x.Id, x.Name, x.Category, x.ProductType, x.ImageLink }).ToList();
            var response = new StoreAnalytics()
            {
                Stores = new List<StoreAnalyticsItem>()
            };

            foreach(var store in stores)
            {
                var allStoreLogs = logs.Where(l => l.Store.ToLower() == store.Name.ToLower() && 
                                                   l.StoreAddress.ToLower() == store.Address.ToLower() && 
                                                   l.StoreCity.ToLower() == store.City.ToLower()).ToList();

                var storeItem = new StoreAnalyticsItem()
                {
                    StoreId = store.Id,
                    StoreName = store.Name,
                    StoreImage = store.ImageLink,
                    Ravenue = Math.Round(allStoreLogs.Where(l => !l.Returned).Sum(l => l.Total), 2),
                    SoldProducts = allStoreLogs.Where(l => !l.Returned).ToList().Count,
                    ReturnedProduct = allStoreLogs.Where(l => l.Returned).ToList().Count,
                    Products = new List<ProductAnalyticsItem>()
                };



                foreach (var product in products)
                {
                    var allProductLogs = logs.Where(l => l.Product.ToLower() == product.Name.ToLower() &&
                                                         l.Category.ToLower() == product.Category.Name.ToLower() &&
                                                         l.ProductType.ToLower() == product.ProductType.ToString().ToLower() &&
                                                         l.Store.ToLower() == store.Name.ToLower() &&
                                                         l.StoreAddress.ToLower() == store.Address.ToLower() &&
                                                         l.StoreCity.ToLower() == store.City.ToLower()).ToList();

                    if(allProductLogs.Sum(p => p.Total) != 0)
                    {
                        storeItem.Products.Add(new ProductAnalyticsItem()
                        {
                            ProductId = product.Id,
                            ProductImage = product.ImageLink,
                            ProductName = product.Name,
                            Category = product.Category.Name,
                            ProductType = product.ProductType.ToString(),
                            Ravenue = Math.Round(allProductLogs.Where(p => !p.Returned).Sum(p => p.Total), 2),
                            TimesReturned = allProductLogs.Where(p => p.Returned).ToList().Count,
                            TimesSold = allProductLogs.Where(p => !p.Returned).ToList().Count
                        });
                    }                   
                }
                storeItem.Products = storeItem.Products.OrderByDescending(s => s.Ravenue).ToList();
                response.Stores.Add(storeItem);
            }

            response.Stores = response.Stores.OrderByDescending(o => o.Ravenue).Take(amount).ToList();
            return response;
        }

        public ProductAnalytics GetProductAnalytics(int amount)
        {
            var products = _context.Products.Include(p=>p.Category).Select(x => new { x.Id, x.Name, x.Category, x.ProductType, x.ImageLink }).ToList();
            var logs = _context.PurchaseLogs.ToList();
            var response = new ProductAnalytics()
            {
                Products = new List<ProductAnalyticsItem>()
            };

            foreach (var product in products)
            {
                var allProductLogs = logs.Where(l => l.Product.ToLower() == product.Name.ToLower() &&
                                                     l.Category.ToLower() == product.Category.Name.ToLower() && 
                                                     l.ProductType.ToLower() == product.ProductType.ToString().ToLower()).ToList();

                response.Products.Add(new ProductAnalyticsItem()
                {
                    ProductId = product.Id, 
                    ProductImage = product.ImageLink, 
                    ProductName = product.Name, 
                    Category = product.Category.Name,
                    ProductType = product.ProductType.ToString(),
                    Ravenue = Math.Round(allProductLogs.Where(p => !p.Returned).Sum(p => p.Total), 2),
                    TimesReturned = allProductLogs.Where(p => p.Returned).ToList().Count,
                    TimesSold = allProductLogs.Where(p => !p.Returned).ToList().Count
                });
            }
            response.Products = response.Products.OrderByDescending(o => o.Ravenue).Take(amount).ToList();
            return response;
        }

        public CategoryAnalytics GetCategoryAnalytics(int amount)
        {
            var categories = _context.Categories.Select(x => new { x.Id, x.Name, x.ImageLink }).ToList();
            var logs = _context.PurchaseLogs.ToList();
            var response = new CategoryAnalytics()
            {
                Categories = new List<CategoryAnalyticsItem>()
            };

            foreach (var category in categories)
            {
                var allCategoryLogs = logs.Where(l => l.Category.ToLower() == category.Name.ToLower()).ToList();

                response.Categories.Add(new CategoryAnalyticsItem()
                {
                    CategoryImage = category.ImageLink, 
                    CategoryId = category.Id, 
                    CategoryName = category.Name, 
                    Ravenue = Math.Round(allCategoryLogs.Where(c => !c.Returned).Sum(c => c.Total), 2),
                    SoldProducts = allCategoryLogs.Where(l => !l.Returned).ToList().Count,
                    ReturnedProduct = allCategoryLogs.Where(l => l.Returned).ToList().Count
                });
            }

            response.Categories = response.Categories.OrderByDescending(o => o.Ravenue).Take(amount).ToList();
            return response;
        }

        public ProductTypeAnalytics GetProductTypeAnalytics(int amount)
        {

            var logs = _context.PurchaseLogs.ToList();

            var response = new ProductTypeAnalytics()
            {
                Types = new List<ProductTypeAnalyticsItem>()
            };

            foreach (GrocerioModels.Enums.Product.Type type in (GrocerioModels.Enums.Product.Type[])Enum.GetValues(typeof(GrocerioModels.Enums.Product.Type)))
            {
                var allProductTypeLogs = logs.Where(l => l.ProductType.ToLower() == type.ToString().ToLower()).ToList();

                response.Types.Add(new ProductTypeAnalyticsItem()
                {
                   TypeName = type.ToString(), 
                   Ravenue = Math.Round(allProductTypeLogs.Where(c => !c.Returned).Sum(c => c.Total), 2),
                   SoldProducts = allProductTypeLogs.Where(l => !l.Returned).ToList().Count,
                   ReturnedProduct = allProductTypeLogs.Where(l => l.Returned).ToList().Count
                });
            }

            response.Types = response.Types.OrderByDescending(o => o.Ravenue).Take(amount).ToList();
            return response;
        }
    }
}
