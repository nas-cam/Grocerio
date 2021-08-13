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

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Required]
        [MinLength(3)]
        public string City { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string ImageLink { get; set; }

        [Required]
        public NewCreditCardModel MainCreditCard { get; set; }
    }
}
