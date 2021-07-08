using GrocerioModels.Enums.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Database.Entities
{
    public class PurchaseLog
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
        public string Category { get; set; }
        public string ProductType { get; set; }
        public string User { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentIdentifier { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ArrivedAt { get; set; }
        public DateTime LogMade { get; set; }
        public int OriginalPurchaseId { get; set; }
        public bool Returned { get; set; }
        public string ReturnReason { get; set; }
        public Priority Seriousness { get; set; }
        public string StringSeriousness { get; set; }
    }
}
