using GrocerioApi.CBF.Algorithm;
using GrocerioApi.CBF.Models.Store;
using GrocerioApi.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.CBF.Calculations
{
    public class StoreCalculations
    {

        private readonly GrocerioContext _context;

        public StoreCalculations(GrocerioContext context)
        {
            _context = context;
        }

        #region PrivateMethods

        private string GetStoreWordBag(GrocerioModels.Store.Model.StoreModel store)
        {
            return store.Name.ToLower() + "_" + store.City.ToLower() + "_" + store.Address.ToLower();
        }

        private string GetStoreParameterItemWordBag(StoreParameterItem parameterItem)
        {
            return parameterItem.StoreName.ToLower() + "_" + parameterItem.StoreCity.ToLower() + "_" + parameterItem.StoreAddress.ToLower();
        }

        private double CalcaulteStoreScore(GrocerioModels.Store.Model.StoreModel store, StoreParameters parameters )
        {
            double score = 0;
            string storeWordBag = GetStoreWordBag(store);

            foreach(var shoppingCartStore in parameters.ShoppingCartStores)
            {
                var shoppingCartStoreWordBag = GetStoreParameterItemWordBag(shoppingCartStore);
                score += Similarity.CalculateSimilarity(storeWordBag, shoppingCartStoreWordBag);
            }
            foreach (var trackingStore in parameters.TrackingStores)
            {
                var trackingStoreWordBag = GetStoreParameterItemWordBag(trackingStore);
                score += Similarity.CalculateSimilarity(storeWordBag, trackingStoreWordBag);
            }
            foreach (var purchaseStore in parameters.PurchaseStores)
            {
                var purchaseStoreWordBag = GetStoreParameterItemWordBag(purchaseStore);
                score += Similarity.CalculateSimilarity(storeWordBag, purchaseStoreWordBag);
            }
            return score;
        }
        #endregion

        public List<GrocerioModels.Store.Model.StoreModel> SortStores(List<GrocerioModels.Store.Model.StoreModel> stores, int userId)
        {
            List<StoreScore> scoredStores = new List<StoreScore>();

            #region GetUsersData
            var shoppingCartStores = _context.ShoppingCart
                                       .Include(c => c.StoreProduct)
                                       .ThenInclude(sp => sp.Store)
                                       .Where(c => c.UserId == userId)
                                       .Select(c => new StoreParameterItem() { 
                                           StoreAddress = c.StoreProduct.Store.Address.ToLower(),
                                           StoreCity = c.StoreProduct.Store.City.ToLower(),
                                           StoreName = c.StoreProduct.Store.Name.ToLower()
                                       }) 
                                       .ToList();
            var trackingStores = _context.Trackings
                                         .Where(t => t.UserId == userId)
                                         .Select(t => new StoreParameterItem() {
                                             StoreAddress = t.StoreAddress.ToLower(),
                                             StoreCity = t.StoreCity.ToLower(),
                                             StoreName = t.Store.ToLower()
                                         })
                                         .ToList();

            var purchaseStores = _context.Purchases
                                         .Where(p => p.UserId == userId)
                                           .Select(p => new StoreParameterItem()
                                           {
                                               StoreAddress = p.StoreAddress.ToLower(),
                                               StoreCity = p.StoreCity.ToLower(),
                                               StoreName = p.Store.ToLower()
                                           })
                                         .ToList();
            if (shoppingCartStores.Count == 0 && trackingStores.Count == 0 && purchaseStores.Count == 0) return stores.OrderBy(s => s.Name).ToList();
            #endregion

            #region CalculateStoresScore
            foreach (var store in stores)
            {
                StoreScore storeScore = new StoreScore()
                {
                    StoreId = store.Id, 
                    StoreName = store.Name,
                    Score = CalcaulteStoreScore(store, new StoreParameters() { 
                        PurchaseStores = purchaseStores, 
                        ShoppingCartStores = shoppingCartStores, 
                        TrackingStores = trackingStores
                    })
                };
                scoredStores.Add(storeScore);
            }
            #endregion

            #region SortStores
            var sortedStores = new List<GrocerioModels.Store.Model.StoreModel>();
            foreach (var scoredStore in scoredStores.OrderByDescending(s => s.Score).ToList()) 
                sortedStores.Add(stores.Single(s => s.Id == scoredStore.StoreId));
            #endregion

            return sortedStores;
        }
    }
}
