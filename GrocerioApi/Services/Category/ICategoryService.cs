using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioModels.Requests.Category;
using GrocerioModels.Response.Category;

namespace GrocerioApi.Services.Category
{
    public interface ICategoryService
    {
        InsertCategoryResponse Insert(InsertCategoryRequest request);
        List<GrocerioModels.Category.Category> GetAllCategories(string searchTerm);
        GrocerioModels.Category.Category GetCategoryById(int categoryId);
        InsertCategoryResponse EditCategory(EditCategoryRequest request);
    }
}
