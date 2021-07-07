using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GrocerioModels.CreditCard
{
    public class NewCreditCardModel
    {
        //TODO
        //Validate real credit card data
        [Required]
        public string CardHolder { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string Expiration { get; set; }
        [Required]
        public string CVV { get; set; }
    }
}
