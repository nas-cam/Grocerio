using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioApi.Services.Store;
using GrocerioModels.Requests.Store;
using GrocerioModels.Response;
using GrocerioModels.Response.Store;
using Microsoft.AspNetCore.Authorization;
using GrocerioModels.Filters.Store;

namespace GrocerioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<GrocerioModels.Response.Store.InsertStoreResponse> Insert(
            [FromBody] GrocerioModels.Requests.Store.InsertStoreRequest request)
        {

            var response = _storeService.Insert(request);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            return Ok(response);
        }

        [HttpGet("GetMissingProducts/{storeId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<GrocerioModels.Product.MinifiedProduct>> GetMissingProducts(int storeId)
        {
            var response = _storeService.GetMissingProducts(storeId);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid store id" });
            return Ok(response);
        }

        [HttpPost("AddProduct/{storeId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ProductManipulationResponse> AddProduct(int storeId, [FromBody] ProductManipulationRequest request)
        {
            var response = _storeService.AddProduct(storeId, request);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            return Ok(response);
        }

        [HttpPost("RemoveProduct/{storeId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ProductManipulationResponse> RemoveProduct(int storeId, [FromBody] ProductRemovalRequest request)
        {
            var response = _storeService.RemoveProduct(storeId, request);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            return Ok(response);
        }

        [HttpGet("GetStoreCategories/{storeId}/{missing}")]
        [Authorize]
        public ActionResult<List<GrocerioModels.Category.Category>> GetStoreCategories(int storeId, bool missing = false)
        {
            var response = _storeService.GetStoreCategories(storeId, missing);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid store id" });
            return Ok(response);
        }

        [HttpGet("GetStoreById/{storeId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<GrocerioModels.Store.Model.StoreModel> GetStoreById(int storeId)
        {
            var response = _storeService.GetStoreById(storeId);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid store id" });
            return Ok(response);
        }

        [HttpPost("ReceiveStores")]
        [Authorize]
        public ActionResult<List<GrocerioModels.Store.Model.StoreModel>> ReceiveStores([FromBody] StoreFilters storeFilters)
        {
            var response = _storeService.ReceiveStores(storeFilters);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid user id" });
            return Ok(response);
        }
    }
}
