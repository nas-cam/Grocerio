using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GrocerioApi.Database.Context;
using GrocerioApi.Database.Entities;
using GrocerioModels.Filters.Store;
using GrocerioModels.Product;
using GrocerioModels.Requests.Store;
using GrocerioModels.Response.Store;
using GrocerioModels.Utils;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;

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

        #region PrvateMethods
        private ProductManipulationResponse ValidateStoreInformation(int storeId)
        {
            //prepare response
            var response = new ProductManipulationResponse() { Success = false, ProductList = new List<MinifiedProductWithPrice>(), Message = "" };

            //validate store id
            var store = _context.Stores.Select(x => new { x.Id, x.Name }).SingleOrDefault(s => s.Id == storeId);
            if (store == null)
            {
                response.Message = $"Invalid store id: {storeId}";
                return response;
            }

            //check if store has at least one product
            var validStoreProduct = _context.StoreProducts.Select(x => new { x.Id, x.StoreId }).FirstOrDefault(sp => sp.StoreId == storeId);
            if (validStoreProduct == null)
            {
                response.Message = "The store must have at least one product registered";
                return response;
            }
            return response;
        }

        private List<MinifiedProduct> GetMinifiedProductsFromDatabase()
        {
            return _context.Products
               .Select(x => new MinifiedProduct
               {
                   Name = x.Name,
                   CategoryId = x.CategoryId,
                   Description = x.Description,
                   Id = x.Id,
                   ImageLink = x.ImageLink,
                   ProductType = x.ProductType
               }).ToList();
        }

        private MinifiedProductWithPrice CreateMinifiedProductWithPrice(int productId, double price, List<MinifiedProduct> products)
        {

            var dbProduct = products.Single(p => p.Id == productId);
            return new MinifiedProductWithPrice()
            {
                Name = dbProduct.Name,
                CategoryId = dbProduct.CategoryId,
                Description = dbProduct.Description,
                Id = dbProduct.Id,
                ImageLink = dbProduct.ImageLink,
                ProductType = dbProduct.ProductType,
                Price = price
            };
        }

        private GrocerioModels.Store.Model.StoreModel CreateStoreModel(int storeId)
        {
            //get database store
            var dbStore = _context.Stores.Include(s => s.StoreProducts).ThenInclude(sp => sp.Product).ThenInclude(p=>p.Category).Single(s => s.Id == storeId);
            var store = new GrocerioModels.Store.Model.StoreModel()
            {
                Id = dbStore.Id, 
                Address = dbStore.Address, 
                UniqueStoreNumber = dbStore.UniqueStoreNumber, 
                Description = dbStore.Description, 
                ImageLink = dbStore.ImageLink, 
                Membership = dbStore.Membership, 
                MembershipName = dbStore.Membership.ToString(), 
                Name = dbStore.Name, 
                Categories = GetStoreCategories(storeId, false), 
                MissingCategories = GetStoreCategories(storeId, true),
                StoreProducts = new List<GrocerioModels.Store.Model.StoreProductModel>()
            };

            foreach(var storeProduct in dbStore.StoreProducts)
                store.StoreProducts.Add(new GrocerioModels.Store.Model.StoreProductModel()
                {
                    Price = storeProduct.Price,
                    Registered = storeProduct.Registered,
                    StoreProductId = storeProduct.Id,
                    Product = new GrocerioModels.Store.Model.ProductModel()
                    {
                        Id = storeProduct.Product.Id,
                        CategoryId = storeProduct.Product.CategoryId,
                        CategoryName = storeProduct.Product.Category.Name.ToString(),
                        Description = storeProduct.Product.Description,
                        ImageLink = storeProduct.Product.ImageLink,
                        Name = storeProduct.Product.Name,
                        ProductType = storeProduct.Product.ProductType,
                        ProductTypeName = storeProduct.Product.ProductType.ToString()
                    }
                }
                );

            return store;
        }
        #endregion

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

        public List<GrocerioModels.Product.MinifiedProduct> GetMissingProducts(int storeId)
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

            return _mapper.Map<List<GrocerioModels.Product.MinifiedProduct>>(missingProducts);
        }

        public ProductManipulationResponse AddProduct(int storeId, ProductManipulationRequest request)
        {
            //validate store
            var response = ValidateStoreInformation(storeId);
            if (!string.IsNullOrWhiteSpace(response.Message)) return response;

            //check if request is empty
            if (request.Products.Count == 0)
            {
                response.Message = "No products are received from the request";
                return response;
            }

            //get already registered products
            var registeredProductIds =
                _context.StoreProducts.Where(sp => sp.StoreId == storeId).Select(x => x.ProductId).ToList();

            //get all products from database
            var products = GetMinifiedProductsFromDatabase();

            //add in new products
            foreach (var product in request.Products)
            {
                if (products.Where(p => p.Id == product.ProductId).ToList().Count == 0)
                {
                    response.Message = $"Invalid product id: {product.ProductId}";
                    return response;
                }
                if(product.Price == 0)
                {
                    response.Message = $"The price for product with the id {product.ProductId} is set to 0";
                    return response;
                }
                if (!registeredProductIds.Contains(product.ProductId))
                {
                    _context.StoreProducts.Add(new StoreProducts()
                    {
                        ProductId = product.ProductId, 
                        StoreId =  storeId, 
                        Price = product.Price,
                        Registered = Get.CurrentDate(),
                    });
                    _context.SaveChanges();
                    response.ProductList.Add(CreateMinifiedProductWithPrice(product.ProductId, product.Price, products));
                }
            }

            if (response.ProductList.Count == 0)
            {
                response.Message = "The wanted products are already inside the store";
                return response;
            }

            response.Success = true;
            var store = _context.Stores.Select(x => new { x.Id, x.Name }).SingleOrDefault(s => s.Id == storeId);
            response.Message = "New products added in successfully";
            response.StoreName = store.Name;
            response.StoreId = store.Id;

            return response;
        }

        public ProductManipulationResponse RemoveProduct(int storeId, ProductRemovalRequest request)
        {
            //validate store
            var response = ValidateStoreInformation(storeId);
            if (!string.IsNullOrWhiteSpace(response.Message)) return response;

            //check if request is empty
            if (request.ProductIds.Count == 0)
            {
                response.Message = "No products are received from the request";
                return response;
            }

            //get already registered products
            var registeredProducts =
                _context.StoreProducts.Where(sp => sp.StoreId == storeId).ToList();

            if(registeredProducts.Count == 1)
            {
                response.Message = $"The store must have at least one product left, the current one has the id: {registeredProducts[0].ProductId}";
                return response;
            }

            //get all products from database
            var products = GetMinifiedProductsFromDatabase();

            //remove products from store
            foreach (var productId in request.ProductIds)
            {
                var productToRemove = registeredProducts.SingleOrDefault(rp => rp.ProductId == productId);
                if(productToRemove == null)
                {
                    response.Message = $"Invalid product id: {productId}";
                    return response;
                }
                _context.StoreProducts.Remove(productToRemove);
                _context.SaveChanges();
                response.ProductList.Add(CreateMinifiedProductWithPrice(productId, productToRemove.Price, products));               
            }

            response.Success = true;
            var store = _context.Stores.Select(x => new { x.Id, x.Name }).SingleOrDefault(s => s.Id == storeId);
            response.Message = "Products removed successfully";
            response.StoreName = store.Name;
            response.StoreId = store.Id;

            return response;
        }

        public List<GrocerioModels.Category.Category> GetStoreCategories(int storeId, bool missing)
        {
            //validate store id
            var store = _context.Stores.Select(x => new { x.Id, x.Name }).SingleOrDefault(s => s.Id == storeId);
            if (store == null) return null;

            switch (missing)
            {
                case true:
                    List<Database.Entities.Category> allStoreCategories =
                        _context.StoreProducts
                        .Include(sp => sp.Product)
                        .ThenInclude(p => p.Category)
                        .Where(sp => sp.StoreId == storeId)
                        .Select(sp => sp.Product.Category)
                        .Distinct()
                        .ToList();

                    var allDatabaseCategories = _context.Categories.ToList();
                    var missingCategories = new List<Database.Entities.Category>();

                    foreach (var category in allDatabaseCategories)
                        if (!allStoreCategories.Contains(category)) missingCategories.Add(category);

                    return _mapper.Map<List<GrocerioModels.Category.Category>>(missingCategories);

                case false:
                    return _mapper.Map<List<GrocerioModels.Category.Category>>(
                        _context.StoreProducts
                        .Include(sp => sp.Product)
                        .ThenInclude(p => p.Category)
                        .Where(sp => sp.StoreId == storeId)
                        .Select(sp => sp.Product.Category)
                        .Distinct()
                        .ToList());
            }
        }

        public GrocerioModels.Store.Model.StoreModel GetStoreById(int storeId)
        {
            //validate store id
            var store = _context.Stores.Select(x => new { x.Id, x.Name }).SingleOrDefault(s => s.Id == storeId);
            if (store == null) return null;
            return CreateStoreModel(storeId);
        }

        public List<GrocerioModels.Store.Model.StoreModel> ReceiveStores(StoreFilters storeFilters)
        {
            //get and validate user
            var account = _context.Accounts
                .Select(x => new { x.AccountId, x.Username })
                .SingleOrDefault(a => a.AccountId == storeFilters.AccountId);
            if (account == null) return null;

            //get all store data from database as a query
            var allStoresQuery = _context.Stores
                .Include(s => s.StoreProducts)
                .ThenInclude(sp => sp.Product)
                .ThenInclude(p => p.Category)
                .AsQueryable();

            #region Filtering

            //filter stores
            var searchTerm = storeFilters.SearchTerm.ToLower(); //lower the search term
            if (!string.IsNullOrWhiteSpace(storeFilters.SearchTerm))
                allStoresQuery = allStoresQuery
                    .Where(s => s.Name.ToLower().Contains(searchTerm) ||
                                s.Description.ToLower().Contains(searchTerm) ||
                                s.Address.ToLower().Contains(searchTerm));

            if (storeFilters.Membership != 0)
                allStoresQuery = allStoresQuery.Where(s => s.Membership == storeFilters.Membership);

            #endregion



           throw new NotImplementedException();
        }
    }
}
