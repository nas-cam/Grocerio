using GrocerioModels.Enums.Notification;
using GrocerioModels.Notification;
using GrocerioModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Notification
{
    public interface INotificationService
    {
        List<NotificationModel> GetNotifications(int accountId);
        BoolResponse ClearNotification(int notificationId, int accountId);
        void AddNotification(string Message, NotificationCategory notificationCategory, int accountId);
    }
}
