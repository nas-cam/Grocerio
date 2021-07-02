using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.ShoppingCart
{
    public class CreditCardInformation
    {
        /*
        TO-DO
        add in validation for credit card information
        all data should be required as well
        */
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
    }
}
