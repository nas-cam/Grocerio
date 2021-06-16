using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioApi.Services.Product;
using GrocerioModels.Product;
using GrocerioModels.Requests.Product;
using GrocerioModels.Response.Product;
using Microsoft.AspNetCore.Authorization;

namespace GrocerioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProductTypes")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<ProructTypeItem>> GetProductTypes()
        {
            return Ok(_productService.GetProductTypes());
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<InsertProductResponse> Insert([FromBody] InsertProductRequest request)
        {
            var response = _productService.Insert(request);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpGet("GetById/{productId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<GrocerioModels.Category.Category> GetProductById(int productId)
        {
            var response = _productService.GetProductById(productId);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<GrocerioModels.Product.Product> GetAllProducts([FromQuery] string searchTerm, int categoryId, GrocerioModels.Enums.Product.Type productType)
        {
            return Ok(_productService.GetAllProducts(searchTerm, categoryId, productType));
        }

        [HttpPut("EditProduct")]
        [Authorize(Roles = "Admin")]
        public ActionResult<InsertProductResponse> EditProduct([FromBody] EditProductRequest request)
        {
            var response = _productService.EditProduct(request);
            if (response == null) return NotFound();
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }
    }
}
