using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GrocerioModels.Enums.Store;
using GrocerioModels.Store;

namespace GrocerioModels.Requests.Store
{
    public class InsertStoreRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Description { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Address { get; set; }

        [Required]
        public Membership Membership { get; set; }

        [Required]
        public string ImageLink { get; set; }

        [Required]
        public int UniqueStoreNumber { get; set; }

        [Required]
        public List<NewStoreProductItem> ProductItems { get; set; }
    }
}
