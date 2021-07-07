using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Database.Entities
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public bool Main { get; set; }
        public DateTime AddedOn { get; set; }
        public bool Active { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Tracking> Trackings { get; set; }
        public List<Purchase> Purchases { get; set; }
    }
}
