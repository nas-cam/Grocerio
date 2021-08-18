using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.CreditCard
{
    public class CensoredCardData
    {
        public int CardId { get; set; }
        public bool Main { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CardHolder { get; set; }
        public string CVV { get; set; }
        public DateTime AddedOn { get; set; }
        public bool Active { get; set; }
    }
}
