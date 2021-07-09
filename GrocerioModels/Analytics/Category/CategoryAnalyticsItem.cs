using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Analytics.Category
{
    public class CategoryAnalyticsItem
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public double Ravenue { get; set; }
        public int SoldProducts { get; set; }
        public int ReturnedProduct { get; set; }
    }
}
