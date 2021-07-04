using GrocerioApi.CBF.Algorithm;
using GrocerioApi.CBF.Models.Product;
using GrocerioApi.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.CBF.Calculations
{
    public class ProductCalculations
    {
        private readonly GrocerioContext _context;

        public ProductCalculations(GrocerioContext context)
        {
            _context = context;
        }

        #region PrivateMethods

        private string GetProductWordBag(GrocerioModels.Store.Model.StoreProductModel product)
        {
            return product.Product.Name.ToLower() + "_" + product.Product.CategoryName.ToLower() + "_" + product.Product.ProductTypeName.ToLower() + "_" + product.Price.ToString();
        }

        private string GetProductParameterItemWordBag(ProductParameterItem parameterItem)
        {
            return parameterItem.ProductName.ToLower() + "_" + parameterItem.ProductCategory.ToLower() + "_" + parameterItem.ProductType.ToLower() + "_" + parameterItem.ProductPrice.ToString();
        }

        private double CalcaulteProductScore(GrocerioModels.Store.Model.StoreProductModel product, ProductParameters parameters)
        {
            double score = 0;
            string productWordBag = GetProductWordBag(product);

            foreach (var shoppingCartProduct in parameters.ShoppingCartProducts)
            {
                var shoppingCartProductWordBag = GetProductParameterItemWordBag(shoppingCartProduct);
                score += Similarity.CalculateSimilarity(productWordBag, shoppingCartProductWordBag);
            }
            foreach (var trackingProduct in parameters.TrackingProducts)
            {
                var trackingProductWordBag = GetProductParameterItemWordBag(trackingProduct);
                score += Similarity.CalculateSimilarity(productWordBag, trackingProductWordBag);
            }
            foreach (var purchaseProduct in parameters.PurchaseProducts)
            {
                var purchaseProductWordBag = GetProductParameterItemWordBag(purchaseProduct);
                score += Similarity.CalculateSimilarity(productWordBag, purchaseProductWordBag);
            }
            return score;
        }
        #endregion

        public List<GrocerioModels.Store.Model.StoreProductModel> SortProducts(List<GrocerioModels.Store.Model.StoreProductModel> products, int userId)
        {
            List<ProductScore> scoredProducts = new List<ProductScore>();

            #region GetUsersData
            var shoppingCartProducts = _context.ShoppingCart
                                       .Include(c => c.StoreProduct)
                                       .ThenInclude(sp => sp.Store)
                                       .Include(c => c.StoreProduct)
                                       .ThenInclude(sp => sp.Product)
                                       .ThenInclude(p=>p.Category)
                                       .Where(c => c.UserId == userId)
                                       .Select(c => new ProductParameterItem()
                                       {
                                          ProductCategory = c.StoreProduct.Product.Category.Name, 
                                          ProductName = c.StoreProduct.Product.Name, 
                                          ProductPrice = c.StoreProduct.Price.ToString(),
                                          ProductType = c.StoreProduct.Product.ProductType.ToString()
                                       })
                                       .ToList();
            var trackingProducts = _context.Trackings
                                         .Where(t => t.UserId == userId)
                                         .Select(t => new ProductParameterItem()
                                         {
                                             ProductType = t.ProductType,
                                             ProductPrice = t.Price.ToString(), 
                                             ProductName = t.Product, 
                                             ProductCategory = t.Category,
                                         })
                                         .ToList();

            var purchaseProducts = _context.Purchases
                                         .Where(p => p.UserId == userId)
                                           .Select(p => new ProductParameterItem()
                                           {
                                               ProductType = p.ProductType, 
                                               ProductCategory = p.Category, 
                                               ProductName = p.Product, 
                                               ProductPrice = p.Price.ToString(),
                                           })
                                         .ToList();
            if (shoppingCartProducts.Count == 0 && trackingProducts.Count == 0 && purchaseProducts.Count == 0) return products.OrderBy(p => p.Product.Name).ToList();
            #endregion

            #region CalculateProductScore
            foreach (var product in products)
            {
                ProductScore storeScore = new ProductScore()
                {
                    ProductId = product.StoreProductId,
                    ProductName = product.Product.Name,
                    Score = CalcaulteProductScore(product, new ProductParameters()
                    {
                        PurchaseProducts = purchaseProducts, 
                        ShoppingCartProducts = shoppingCartProducts, 
                        TrackingProducts = trackingProducts
                    })
                };
                scoredProducts.Add(storeScore);
            }
            #endregion

            #region SortProducts
            var sortedProducts= new List<GrocerioModels.Store.Model.StoreProductModel>();
            foreach (var scoredProduct in scoredProducts.OrderByDescending(s => s.Score).ToList())
                sortedProducts.Add(products.Single(p => p.StoreProductId == scoredProduct.ProductId));
            #endregion

            return sortedProducts;
        }
    }
}
