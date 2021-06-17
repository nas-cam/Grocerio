using System;
using System.Collections.Generic;
using System.Text;
using GrocerioModels.Product;

namespace GrocerioModels.Response.Store
{
    public class ProductManipulationResponse : BoolResponse
    {
        public int StoreId { get; set; }
        public String StoreName { get; set; }
        public List<MinifiedProduct> ProductList { get; set; }
    }
}
