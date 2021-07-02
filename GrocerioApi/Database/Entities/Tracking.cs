using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Database.Entities
{
    public class Tracking
    {
        public int Id { get; set; }
        public string Store { get; set; }
        public string StoreAddress { get; set; }
        public string Product { get; set; }
        public string ProductDescription { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public int DaysLeft { get; set; }
        public DateTime LastUpdated { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public string ShippingAddress { get; set; }

    }
}
