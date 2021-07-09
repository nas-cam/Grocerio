using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Analytics.Product
{
    public class ProductAnalyticsItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string ProductType { get; set; }
        public string ProductImage { get; set; }
        public double Ravenue { get; set; }
        public int TimesSold { get; set;  }
        public int TimesReturned { get; set; }
    }
}
