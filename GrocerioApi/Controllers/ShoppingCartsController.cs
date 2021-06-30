using GrocerioApi.Services.ShoppingCart;
using GrocerioModels.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        public readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartsController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost("AddItem/{userId}/{storeProductId}/{amount}")]
        [Authorize(Roles = "User")]
        public ActionResult<StringResponse> AddItem(int userId, int storeProductId, int amount)
        {
            var response = _shoppingCartService.AddItem(userId, storeProductId, amount);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            return Ok(new StringResponse() { Message = response.Message });
        }
    }
}
