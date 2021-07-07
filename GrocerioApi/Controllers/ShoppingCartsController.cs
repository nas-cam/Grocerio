using GrocerioApi.Services.ShoppingCart;
using GrocerioModels.Enums.General;
using GrocerioModels.Response;
using GrocerioModels.ShoppingCart;
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

        [HttpGet("GetShoppingCart/{userId}")]
        [Authorize(Roles = "User")]
        public ActionResult<ShoppingCartModel> GetShoppingCart(int userId)
        {
            var response = _shoppingCartService.GetShoppingCart(userId);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid user identifier" });
            return Ok(response);    
        }

        [HttpGet("RemoveItem/{cartItemId}/{userId}")]
        [Authorize(Roles = "User")]
        public ActionResult<StringResponse> RemoveItem(int cartItemId, int userId)
        {
            var response = _shoppingCartService.RemoveItem(cartItemId, userId);
            if (!response.Success) return NotFound(new StringResponse() { Message = response.Message });
            return Ok(new StringResponse() { Message = response.Message });
        }

        [HttpGet("SlideCartItemAmountByOne/{cartItemId}/{userId}/{operation}")]
        [Authorize(Roles = "User")]
        public ActionResult<StringResponse> SlideCartItemAmountByOne(int cartItemId, int userId, Operation operation)
        {
            var response = _shoppingCartService.SlideCartItemAmountByOne(cartItemId, userId, operation);
            if (!response.Success) return NotFound(new StringResponse() { Message = response.Message });
            return Ok(new StringResponse() { Message = response.Message });
        }

        [HttpGet("SlideCartItemAmountByMultiple/{cartItemId}/{userId}/{operation}/{amount}")]
        [Authorize(Roles = "User")]
        public ActionResult<StringResponse> SlideCartItemAmountByMultiple(int cartItemId, int userId, Operation operation, int amount)
        {
            var response = _shoppingCartService.SlideCartItemAmountByMultiple(cartItemId, userId, operation, amount);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            return Ok(new StringResponse() { Message = response.Message });
        }

        [HttpPost("Checkout/{userId}/{creditCardId}")]
        [Authorize(Roles = "User")]
        public ActionResult<StringResponse> Checkout(int userId, int creditCardId)
        {
            var response = _shoppingCartService.Checkout(userId, creditCardId);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            return Ok(new StringResponse() { Message = response.Message});
        }

    }
}
