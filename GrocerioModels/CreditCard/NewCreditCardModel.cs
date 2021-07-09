using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GrocerioModels.CreditCard
{
    public class NewCreditCardModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string CardHolder { get; set; }
        
        [Required]
        [MinLength(16)]
        [MaxLength(16)]
        public string CardNumber { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(5)]
        public string Expiration { get; set; }

        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        public string CVV { get; set; }
    }
}
