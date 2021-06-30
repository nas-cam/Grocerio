using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.ShoppingCart
{
    public class ShoppingCartModel
    {
        public double CheckoutTotal { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
    }
}
