using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioApi.Services.Store;
using GrocerioModels.Response;
using Microsoft.AspNetCore.Authorization;

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
            if (!response.Success) return BadRequest(new StringResponse() {Message = response.Message});
            return Ok(response);
        }

        [HttpGet("GetMissingProducts/{storeId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<GrocerioModels.Product.MissingProduct>> GetMissingProducts(int storeId)
        {
            var response = _storeService.GetMissingProducts(storeId);
            if (response == null) return NotFound(new StringResponse() {Message = "Invalid store id"});
            return Ok(response);
        }

    }
}
