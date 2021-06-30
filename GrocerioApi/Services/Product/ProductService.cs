using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GrocerioApi.Database.Context;
using GrocerioModels.Product;
using GrocerioModels.Requests.Product;
using GrocerioModels.Response.Product;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GrocerioApi.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly GrocerioContext _context;
        private readonly IMapper _mapper;

        public ProductService(GrocerioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProructTypeItem> GetProductTypes()
        {
            List<ProructTypeItem> types = new List<ProructTypeItem>();
            foreach (GrocerioModels.Enums.Product.Type type in (GrocerioModels.Enums.Product.Type[])Enum.GetValues(typeof(GrocerioModels.Enums.Product.Type)))
                types.Add(new ProructTypeItem(){Type = type, TypeName = type.ToString()});
            return types.OrderBy(t=>t.TypeName).ToList();
        }

        public InsertProductResponse Insert(InsertProductRequest request)
        {

            //prepare response body
            var response = new InsertProductResponse()
            {
                Success = false,
                Product = request,
                Id = 0,
            };

            //verify category id 
            var category = _context.Categories.SingleOrDefault(c => c.Id == request.CategoryId);
            if (category == null)
            {
                response.Message = $"Invalid category id: {request.CategoryId}";
                return response;
            }

            //check if product already in the database
            var alreadyThereProduct =
                _context.Products.Where(p => p.Name.ToLower() == request.Name.ToLower()).ToList();
            if (alreadyThereProduct.Count != 0)
            {
                response.Message = $"A product with the name '{request.Name}' is already in the system!";
                return response;
            }

            //create and add in new product
            Database.Entities.Product newProduct = _mapper.Map<Database.Entities.Product>(request);
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            response.Success = true;
            response.Id = newProduct.Id;
            response.Message = $"The category '{newProduct.Name}' has been added in successfully";
            return response;
        }

        public GrocerioModels.Product.Product GetProductById(int productId)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == productId);
            if (product == null) return null;
            var responseProduct = _mapper.Map<GrocerioModels.Product.Product>(product);
            responseProduct.Category = _context.Categories.Find(responseProduct.CategoryId).Name;
            responseProduct.ProductTypeName = responseProduct.ProductType.ToString();

            return responseProduct;
        }

        public List<GrocerioModels.Product.Product> GetAllProducts(string searchTerm, int categoryId, GrocerioModels.Enums.Product.Type productType)
        {
            List<GrocerioModels.Product.Product> responseProducts = new List<GrocerioModels.Product.Product>();
            var categories = _context.Categories.Select(x => new {x.Id, x.Name}).ToList();
            var allProducts = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
                allProducts = allProducts.Where(p =>
                    p.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(searchTerm.ToLower()));
            if (categoryId != 0) allProducts = allProducts.Where(p => p.CategoryId == categoryId);
            if(productType != 0) allProducts = allProducts.Where(p => p.ProductType == productType);


            foreach (var product in allProducts.ToList())
            {
                var newProduct = _mapper.Map<GrocerioModels.Product.Product>(product);
                newProduct.Category = categories.Single(c=>c.Id == newProduct.CategoryId).Name;
                newProduct.ProductTypeName = newProduct.ProductType.ToString();
                responseProducts.Add(newProduct);
            }

            return responseProducts.OrderBy(p=>p.Name).ToList();
        }

        public InsertProductResponse EditProduct(EditProductRequest request)
        {
            //check if product id valid
            var product = _context.Products.SingleOrDefault(p => p.Id == request.ProductId);
            if (product == null) return null;

            //prepare response body
            var response = new InsertProductResponse()
            {
                Success = false,
                Id = request.CategoryId,
                Product = new InsertProductRequest()
            };

            //check if product name taken 
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                if (_context.Products.Where(p => p.Id != request.ProductId).Select(x => x.Name.ToLower()).ToList()
                    .Contains(request.Name.ToLower()))
                {
                    response.Message = $"The product '{request.Name}' is already in the system";
                    return response;
                }
            }

            //check if category id valid
            if (request.CategoryId != 0)
            {
                var category = _context.Categories.SingleOrDefault(c => c.Id == request.CategoryId);
                if (category == null)
                {
                    response.Message = $"Invalid category id: {request.CategoryId}";
                    return response;
                }
            }

            //update category
            if (!string.IsNullOrWhiteSpace(request.Name)) product.Name = request.Name;
            if (!string.IsNullOrWhiteSpace(request.Description)) product.Description = request.Description;
            if (!string.IsNullOrWhiteSpace(request.ImageLink)) product.ImageLink = request.ImageLink;
            if (request.CategoryId != 0) product.CategoryId = request.CategoryId;
            if (request.ProductType != 0) product.ProductType = request.ProductType;

            _context.SaveChanges();

            response.Success = true;
            response.Product = _mapper.Map<InsertProductRequest>(product);
            response.Message = $"The product with the id {request.ProductId} has been updated successfully";

            return response;
        }
    }
}
