using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using GrocerioApi.Database.Context;
using GrocerioModels.Requests.Category;
using GrocerioModels.Response.Category;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace GrocerioApi.Services.Category
{
    public class CategoryService : ICategoryService
    {
        public readonly GrocerioContext _context;
        public readonly IMapper _mapper;

        public CategoryService(GrocerioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public InsertCategoryResponse Insert(InsertCategoryRequest request)
        {
            //prepare response body
            var response = new InsertCategoryResponse()
            {
                Success = false, 
                Category = request, 
                Id = 0,
            };

            //check if category already in the database
            var alreadyThereCategory =
                _context.Categories.Where(c => c.Name.ToLower() == request.Name.ToLower()).ToList();
            if (alreadyThereCategory.Count != 0)
            {
                response.Message = $"A category with the name '{request.Name}' is already in the system!";
                return response;
            }

            //create and add in new category
            Database.Entities.Category newCategory = _mapper.Map<Database.Entities.Category>(request);
            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            response.Success = true;
            response.Id = newCategory.Id;
            response.Message = $"The category '{newCategory.Name}' has been added in successfully";
            return response;
        }

        public List<GrocerioModels.Category.Category> GetAllCategories(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _mapper.Map<List<GrocerioModels.Category.Category>>(_context.Categories.OrderBy(c=>c.Name).ToList());
            return _mapper.Map<List<GrocerioModels.Category.Category>>(_context.Categories.Where(c =>
                    c.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower())).OrderBy(c => c.Name).ToList());
        }

        public GrocerioModels.Category.Category GetCategoryById(int categoryId)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == categoryId);
            if (category == null) return null;
            return _mapper.Map<GrocerioModels.Category.Category>(category);
        }

        public InsertCategoryResponse EditCategory(EditCategoryRequest request)
        {

            //check if category id valid
            var category = _context.Categories.SingleOrDefault(c => c.Id == request.CategoryId);
            if (category == null) return null;

            //prepare response body
            var response = new InsertCategoryResponse()
            {
                Success = false,
                Id = request.CategoryId,
                Category = new InsertCategoryRequest()
            };

            //check if category name taken 
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                if (_context.Categories.Where(c => c.Id != request.CategoryId).Select(x => x.Name.ToLower()).ToList()
                    .Contains(request.Name.ToLower()))
                {
                    response.Message = $"The category '{request.Name}' is already in the system";
                    return response;
                }
            }

            //update category
            if (!string.IsNullOrWhiteSpace(request.Name)) category.Name = request.Name;
            if (!string.IsNullOrWhiteSpace(request.Description)) category.Description = request.Description;
            if (!string.IsNullOrWhiteSpace(request.ImageLink)) category.ImageLink = request.ImageLink;

            _context.SaveChanges();

            response.Success = true;
            response.Category = _mapper.Map<InsertCategoryRequest>(category);
            response.Message = $"The category with the id {request.CategoryId} has been updated successfully";

            return response;
        }
    }
}
