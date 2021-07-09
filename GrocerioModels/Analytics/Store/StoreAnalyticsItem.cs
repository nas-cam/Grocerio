using GrocerioModels.Analytics.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Analytics.Store
{
    public class StoreAnalyticsItem
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreImage { get; set; }
        public double Ravenue { get; set; }
        public int SoldProducts { get; set; }
        public int ReturnedProduct { get; set; }
        public List<ProductAnalyticsItem> Products { get; set; }
    }
}
