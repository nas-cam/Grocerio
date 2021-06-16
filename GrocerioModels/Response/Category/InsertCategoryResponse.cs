using System;
using System.Collections.Generic;
using System.Text;
using GrocerioModels.Requests.Category;

namespace GrocerioModels.Response.Category
{
    public class InsertCategoryResponse : BoolResponse
    {
        public int Id { get; set; }
        public InsertCategoryRequest Category { get; set; }
    }
}
