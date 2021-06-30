using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Database.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("StoreProducts")]
        public int StoreProductId { get; set; }
        public StoreProducts StoreProduct { get; set; }

        public int Amount { get; set; }

        public DateTime AddedIn { get; set; }
        public DateTime Updated { get; set; }
    }
}
