using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageLink { get; set; }
        public bool Locked { get; set; }
        public bool Active { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
