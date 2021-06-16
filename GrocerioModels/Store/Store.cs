using System;
using System.Collections.Generic;
using System.Text;
using GrocerioModels.Enums.Store;

namespace GrocerioModels.Store
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Membership Membership { get; set; }
        public string ImageLink { get; set; }
        public int UniqueStoreNumber { get; set; }
        public List<StoreProducts> StoreProducts { get; set; }
    }
}
