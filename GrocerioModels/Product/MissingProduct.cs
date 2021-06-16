using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Product
{
    public class MissingProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public GrocerioModels.Enums.Product.Type ProductType { get; set; }
        public int CategoryId { get; set; }
    }
}
