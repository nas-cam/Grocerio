using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GrocerioModels.Requests.User
{
    public class EditUserRequest
    {
        [EmailAddress]
        public string Mail { get; set; }
        
        [MinLength(4)]
        public string FirstName { get; set; }
        
        [MinLength(4)]
        public string LastName { get; set; }
        
        [RegularExpression(@"\(?\d{3}\)?-? ?/*\d{3}-? *-?\d{3}", ErrorMessage = "Invalid phone format")]
        public string PhoneNumber { get; set; }
        
        [MinLength(5)]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string ImageLink { get; set; }

        public string Username { get; set; }
    }
}
