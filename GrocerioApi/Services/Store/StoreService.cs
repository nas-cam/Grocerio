using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GrocerioApi.Database.Context;
using GrocerioApi.Database.Entities;
using GrocerioModels.Requests.Store;
using GrocerioModels.Utils;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace GrocerioApi.Services.Store
{
    public class StoreService : IStoreService
    {
        private readonly GrocerioContext _context;
        private readonly IMapper _mapper;

        public StoreService(GrocerioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GrocerioModels.Response.Store.InsertStoreResponse Insert(InsertStoreRequest request)
        {

            //prepare response
            var response = new GrocerioModels.Response.Store.InsertStoreResponse() {Success = false};

            //at least one product must bee added in upon creation
            if (request.ProductItems.Count == 0)
            {
                response.Message = "At least one product must bee added in upon creation";
                return response;
            }

            //check if there are duplicate products
            if (request.ProductItems.Select(pi=>pi.ProductId).ToList().Count != request.ProductItems.Select(pi => pi.ProductId).Distinct().ToList().Count)
            {
                response.Message = "Duplicate product items were detected";
                return response;
            }

            //check unique store number
            var storeNumbers = _context.Stores.Select(s => s.UniqueStoreNumber).ToList();
            if (storeNumbers.Contains(request.UniqueStoreNumber))
            {
                response.Message = $"The unique store number {request.UniqueStoreNumber} is already in the system";
                return response;
            }

            //validate product ids
            var allProductIds = _context.Products.Select(p => p.Id).ToList();
            var newProductIds = request.ProductItems.Select(pi => pi.ProductId);
            bool allProductsValid = true;
            int firstInvalidProductId = 0;
            foreach (var productId in newProductIds)
            {
                if (!allProductIds.Contains(productId))
                {
                    allProductsValid = false;
                    firstInvalidProductId = productId;
                    break;
                }
            }

            if (!allProductsValid)
            {
                response.Message = $"The product id {firstInvalidProductId} does not exist";
                return response;
            }

            //prepare new store
            var newStore = new Database.Entities.Store()
            {
                Name = request.Name, 
                Address =  request.Address, 
                Description =  request.Description, 
                ImageLink = request.ImageLink, 
                UniqueStoreNumber = request.UniqueStoreNumber, 
                Membership = request.Membership,
                StoreProducts = new List<StoreProducts>()
            };
            foreach (var productItem in request.ProductItems)
            {
                newStore.StoreProducts.Add(new StoreProducts()
                {
                    ProductId = productItem.ProductId,
                    Price = productItem.Price, 
                    Registered = Get.CurrentDate()
                });
            }

            //save new store
            _context.Stores.Add(newStore);
            _context.SaveChanges();

            //finish response body
            response.Success = true;
            response.Message = $"The store {request.Name} added in successfully";
            response.Store = _mapper.Map<GrocerioModels.Store.Store>(newStore);

            return response;
        }

        public List<GrocerioModels.Product.MissingProduct> GetMissingProducts(int storeId)
        {
            //validate store id
            var store = _context.Stores.Select(x => new { x.Id, x.Name }).SingleOrDefault(s => s.Id == storeId);
            if (store == null) return null;

            //check if store has at least one product
            var validStoreProduct = _context.StoreProducts.Select(x=>new {x.Id, x.StoreId}).FirstOrDefault(sp => sp.StoreId == storeId);
            if (validStoreProduct == null) return null;

            //prepare models for searching algorithm
            var allProducts = _context.Products.ToList();
            var insertedProductIds = _context.StoreProducts.Where(sp => sp.StoreId == storeId).Select(x => x.ProductId)
                .ToList();
            List<Database.Entities.Product> missingProducts = new List<Database.Entities.Product>();

            //search for missing products
            foreach (var product in allProducts)
                if (!insertedProductIds.Contains(product.Id))
                    missingProducts.Add(product);

            return _mapper.Map<List<GrocerioModels.Product.MissingProduct>>(missingProducts);
        }
    }
}
