using GrocerioApi.Services.Purchase;
using GrocerioModels.Purchase;
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
    public class PurchaseController : ControllerBase
    {
        public readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet("GetTrackingItems/{userId}")]
        [Authorize(Roles ="User")]
        public ActionResult<List<TrackingModel>> GetTrackingItems(int userId)
        {
            var response = _purchaseService.GetTrackingItems(userId);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid user id" });
            return Ok(response);
        }

        [HttpPost("RefundTrackingItem/{userId}/{trackingItemId}")]
        [Authorize(Roles = "User")]
        public ActionResult<StringResponse> RefundTrackingItem(int userId, int trackingItemId)
        {
            var response = _purchaseService.RefundTrackingItem(userId, trackingItemId);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            return Ok(new StringResponse() { Message = response.Message });
        }

        [HttpGet("GetPurchasedItems/{userId}")]
        [Authorize(Roles = "User")]
        public ActionResult<List<TrackingModel>> GetPurchasedItems(int userId)
        {
            var response = _purchaseService.GetPurchasedItems(userId);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid user id" });
            return Ok(response);
        }

        [HttpPost("ReturnPurchasedItem/{userId}/{purchasedItemId}/{returnReason}")]
        [Authorize(Roles = "User")]
        public ActionResult<StringResponse> ReturnPurchasedItem(int userId, int purchasedItemId, string returnReason)
        {
            var response = _purchaseService.ReturnPurchasedItem(userId, purchasedItemId, returnReason);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            return Ok(new StringResponse() { Message = response.Message });
        }
    }
}
