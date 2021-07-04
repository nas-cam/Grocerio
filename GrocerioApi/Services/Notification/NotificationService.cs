using GrocerioApi.Database.Context;
using GrocerioModels.Enums.Notification;
using GrocerioModels.Notification;
using GrocerioModels.Response;
using GrocerioModels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly GrocerioContext _context;

        public NotificationService(GrocerioContext context)
        {
            _context = context;
        }      

        public List<NotificationModel> GetNotifications(int accountId)
        {
            var account = _context.Accounts.Select(x => new { x.AccountId, x.Username }).SingleOrDefault(a => a.AccountId == accountId);
            if (account == null) return null;

            var dbNotifications = _context.Notifications.Where(n => n.AccountId == accountId).ToList();
            List<NotificationModel> notifications = new List<NotificationModel>();

            foreach (var dbNotification in dbNotifications)
                notifications.Add(new NotificationModel()
                {
                    AccountId = dbNotification.AccountId,
                    Id = dbNotification.Id, 
                    Message = dbNotification.Message, 
                    NotificationCategory = dbNotification.NotificationCategory, 
                    NotificationCategoryName = dbNotification.NotificationCategory.ToString(), 
                    Timestamp = dbNotification.Timestamp
                });
            return notifications;
        }

        public BoolResponse ClearNotification(int notificationId, int accountId)
        {
            var response = new BoolResponse() { Success = false };

            #region validation
            var account = _context.Accounts.Select(x=> new { x.AccountId, x.Username}).SingleOrDefault(a => a.AccountId == accountId);
            if (account == null)
            {
                response.Message = "Invalid account identifier";
                return response;
            }

            var notification = _context.Notifications.SingleOrDefault(n => n.Id == notificationId);
            if(notification == null)
            {
                response.Message = "Invalid notification identifier";
                return response;
            }
            if(notification.AccountId != accountId)
            {
                response.Message = "The notification does not belong to the forwarded user";
                return response;
            }
            #endregion

            _context.Notifications.Remove(notification);
            _context.SaveChanges();
            response.Success = true;
            response.Message = "Notification cleared successfully";
            return response;
        }

        public void AddNotification(string Message, NotificationCategory notificationCategory, int accountId)
        {
            _context.Notifications.Add(new Database.Entities.Notification()
            {
                AccountId = accountId, 
                Message = Message, 
                NotificationCategory = notificationCategory, 
                Timestamp = Get.CurrentDate()
            });
            _context.SaveChanges();
        }
    }
}
