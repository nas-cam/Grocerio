using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GrocerioModels.Filters.Store
{
    public class ProductFilters
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int StoreId { get; set; }
        public string SearchTerm { get; set; }
        public List<int> CetgoryIds { get; set; }
        public List<GrocerioModels.Enums.Product.Type> Types { get; set; }
    }
}
