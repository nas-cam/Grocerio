using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GrocerioModels.Filters.Store
{
    public class CategoryFilters
    {
        [Required]
        public int AccountId { get; set; }
        public string SearchTerm { get; set; }
    }
}
