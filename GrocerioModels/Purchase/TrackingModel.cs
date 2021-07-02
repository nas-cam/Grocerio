using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Purchase
{
    public class TrackingModel
    {
        public int Id { get; set; }
        public string Store { get; set; }
        public string StoreAddress { get; set; }
        public string StoreCity { get; set; }
        public string Product { get; set; }
        public string ProductDescription { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public int DaysLeft { get; set; }
        public string Category { get; set; }
        public string ProductType { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentIdentifier { get; set; }
        public DateTime Purchased { get; set; }
        public string CurrentLocation { get; set; }
        public string StoreImage { get; set; }
        public string ProductImage { get; set; }
        public string CategoryImage { get; set; }
    }
}
