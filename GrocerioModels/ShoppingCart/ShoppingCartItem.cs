using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.ShoppingCart
{
    public class ShoppingCartItem
    {
        public int CartItemId { get; set; }
        public int StoreProductId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public DateTime AddedIn { get; set; }
        public DateTime Updated { get; set; }
        public string Store { get; set; }

        public int UserId { get; set; }
        public string Username { get; set; }
        public int DeliveryDays { get; set; }
        public double Total { get; set; }
    }
}
