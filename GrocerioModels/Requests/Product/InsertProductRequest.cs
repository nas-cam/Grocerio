using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GrocerioModels.Requests.Product
{
    public class InsertProductRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string ImageLink { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Description { get; set; }

        [Required]
        public GrocerioModels.Enums.Product.Type ProductType { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
