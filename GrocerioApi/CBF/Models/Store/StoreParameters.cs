using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.CBF.Models.Store
{
    public class StoreParameters
    {
        public List<StoreParameterItem> ShoppingCartStores { get; set; }
        public List<StoreParameterItem> TrackingStores { get; set; }
        public List<StoreParameterItem> PurchaseStores { get; set; }
    }
}
