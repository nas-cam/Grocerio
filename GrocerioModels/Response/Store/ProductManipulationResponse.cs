using System;
using System.Collections.Generic;
using System.Text;
using GrocerioModels.Product;

namespace GrocerioModels.Response.Store
{
    public class ProductManipulationResponse : BoolResponse
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public List<MinifiedProductWithPrice> ProductList { get; set; }
    }
}
