using System;
using System.Collections.Generic;
using System.Text;
using GrocerioModels.Requests.Product;

namespace GrocerioModels.Response.Product
{
    public class InsertProductResponse : BoolResponse
    {
        public int Id { get; set; }
        public InsertProductRequest Product { get; set; }
    }
}
