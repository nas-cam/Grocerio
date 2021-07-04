using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.CBF.Models.Product
{
    public class ProductParameters
    {
        public List<ProductParameterItem> ShoppingCartProducts { get; set; }
        public List<ProductParameterItem> TrackingProducts { get; set; }
        public List<ProductParameterItem> PurchaseProducts { get; set; }
    }
}
