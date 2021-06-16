using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Store
{
    public class StoreProducts
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int ProductId { get; set; }

        public double Price { get; set; }
        public DateTime Registered { get; set; }
    }
}
