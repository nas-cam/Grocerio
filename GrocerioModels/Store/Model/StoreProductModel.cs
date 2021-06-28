using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Store.Model
{
    public class StoreProductModel
    {
        public int StoreProductId { get; set; }
        public double Price { get; set; }
        public DateTime Registered { get; set; }
        public ProductModel Product { get; set; }
    }
}
