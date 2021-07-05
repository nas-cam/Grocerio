using GrocerioApi.Services.CustomLogs;
using GrocerioModels.Enums.General;
using GrocerioModels.Enums.Purchase;
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
    [Authorize(Roles = "Admin")]
    public class LogsController : ControllerBase
    {

        private readonly ICustomLogService _logService;

        public LogsController(ICustomLogService logService)
        {
            _logService = logService;
        }

        [HttpGet("GetPurchaseLogs/{state}/{logAmount}/{sortDirection}")]
        public ActionResult<Database.Entities.PurchaseLog> GetPurchaseLogs(PurchaseState state = PurchaseState.All, int logAmount = 20, Sort sortDirection = Sort.DESC)
        {
            return Ok(_logService.GetPurchaseLogs(state, logAmount, sortDirection));
        }

    }
}
