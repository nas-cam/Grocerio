using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioApi.Services.Category;
using GrocerioModels.Requests.Category;
using GrocerioModels.Response.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace GrocerioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<InsertCategoryResponse> Insert([FromBody]InsertCategoryRequest request)
        {
            var response = _categoryService.Insert(request);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<GrocerioModels.Category.Category>> GetAllCategories([FromQuery] string searchTerm)
        {
            return Ok(_categoryService.GetAllCategories(searchTerm));
        }

        [HttpGet("GetById/{categoryId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<GrocerioModels.Category.Category> GetCategoryById(int categoryId)
        {
            var response = _categoryService.GetCategoryById(categoryId);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpPut("EditCategory")]
        [Authorize(Roles = "Admin")]
        public ActionResult<InsertCategoryResponse> EditCategory([FromBody] EditCategoryRequest request)
        {
            var response = _categoryService.EditCategory(request);
            if (response == null) return NotFound();
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }


    }
}
