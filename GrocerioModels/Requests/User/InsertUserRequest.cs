using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GrocerioModels.CreditCard;
using Newtonsoft.Json;

namespace GrocerioModels.Requests.User
{
    public class InsertUserRequest : InsertAccountRequest
    {
        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"\(?\d{3}\)?-? ?/*\d{3}-? *-?\d{3}", ErrorMessage = "Invalid phone format")]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(5)]
        public string Address { get; set; }
        [Required]
        [MinLength(3)]
        public string City { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public string ImageLink { get; set; }

        [Required]
        public NewCreditCardModel MainCreditCard { get; set; }
    }
}
