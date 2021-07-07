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
        public DateTime AddedOn { get; set; }
        public bool Active { get; set; }
    }
}
