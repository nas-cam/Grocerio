using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Analytics.ProductType
{
    public class ProductTypeAnalyticsItem
    {
        public string TypeName { get; set; }
        public double Ravenue { get; set; }
        public int SoldProducts { get; set; }
        public int ReturnedProduct { get; set; }
    }
}
