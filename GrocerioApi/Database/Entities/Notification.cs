using GrocerioModels.Enums.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Database.Entities
{
    public class Notification
    {
        public int Id { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public Account Account { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; }

        public NotificationCategory NotificationCategory { get; set; }
    }
}
