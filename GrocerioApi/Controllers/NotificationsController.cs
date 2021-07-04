using GrocerioApi.Services.Notification;
using GrocerioModels.Notification;
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
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("{accountId}")]
        public ActionResult<List<NotificationModel>> GetNotifications(int accountId)
        {
            var response = _notificationService.GetNotifications(accountId);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid account id" });
            return Ok(response);
        }

        [HttpGet("ClearNotification/{notificationId}/{accountId}")]
        public ActionResult<StringResponse> ClearNotification(int notificationId, int accountId)
        {
            var response = _notificationService.ClearNotification(notificationId, accountId);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            return Ok(new StringResponse() { Message = response.Message });
        }

    }
}
