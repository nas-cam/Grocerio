using GrocerioModels.Enums.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Notification
{
    public class NotificationModel
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; }

        public NotificationCategory NotificationCategory { get; set; }

        public string NotificationCategoryName { get; set; }
    }
}
