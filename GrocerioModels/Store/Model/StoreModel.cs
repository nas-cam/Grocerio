﻿using GrocerioModels.Enums.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Store.Model
{
    public class StoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Membership Membership { get; set; }
        public string MembershipName { get; set; }
        public string ImageLink { get; set; }
        public int UniqueStoreNumber { get; set; }
        public List<StoreProductModel> StoreProducts { get; set; }
        public List<GrocerioModels.Category.Category> Categories { get; set; }
        public List<GrocerioModels.Category.Category> MissingCategories { get; set; }

    }
}
