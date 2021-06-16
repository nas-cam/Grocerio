using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GrocerioModels.Requests.Product
{
    public class EditProductRequest
    {
        [Required]
        public int ProductId { get; set; }
        
        public string Name { get; set; }

        public string ImageLink { get; set; }

        
        public string Description { get; set; }
        
        public GrocerioModels.Enums.Product.Type ProductType { get; set; }
       
        public int CategoryId { get; set; }
    }
}
