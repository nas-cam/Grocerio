using System;
using System.Collections.Generic;
using System.Text;
using GrocerioModels.Store;

namespace GrocerioModels.Requests.Store
{
    public class ProductManipulationRequest
    {
        public List<NewStoreProductItem> Products { get; set; }
    }
}
