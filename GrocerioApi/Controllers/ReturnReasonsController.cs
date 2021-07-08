using GrocerioApi.Services.ReturnReson;
using GrocerioModels.Requests.ReturnReason;
using GrocerioModels.Response;
using GrocerioModels.ReturnReason;
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
    public class ReturnReasonsController : ControllerBase
    {
        private readonly IReturnReasonService _returnReasonService;
        public ReturnReasonsController(IReturnReasonService returnReasonService)
        {
            _returnReasonService = returnReasonService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<ReturnReasonModel> Insert([FromBody] InsertReturnReasonRequest request)
        {         
            return Ok(_returnReasonService.Insert(request));
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<ReturnReasonModel>> GetReturnReasons()
        {
            return Ok(_returnReasonService.GetReturnReasons());
        }

        [HttpGet("GetById/{returnReasonId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ReturnReasonModel> GetById(int returnReasonId)
        {
            var response = _returnReasonService.GetById(returnReasonId);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid return reason id" });
            return Ok(response);
        }

        [HttpPost("UpdateReturnReason/{returnReasonId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ReturnReasonModel> UpdateReturnReason(int returnReasonId, [FromBody]InsertReturnReasonRequest request)
        {
            var response = _returnReasonService.UpdateReturnReason(returnReasonId, request);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid return reason id" });
            return Ok(response);
        }

        [HttpGet("RemoveReturnReason/{returnReasonId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<StringResponse> RemoveReturnReason(int returnReasonId)
        {
            var response = _returnReasonService.RemoveReturnReason(returnReasonId);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid return reason id" });
            return Ok(response);
        }
    }
}
