﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioModels.Enums.Store;

namespace GrocerioApi.Database.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Membership Membership { get; set; }
        public string ImageLink { get; set; }
        public int UniqueStoreNumber { get; set; }

        public List<StoreProducts> StoreProducts { get; set; }
    }
}
