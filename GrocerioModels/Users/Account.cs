using System;
using System.Collections.Generic;
using System.Text;
using GrocerioModels.Enums.User;
using GrocerioModels.Requests.User;

namespace GrocerioModels.Users
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
    }
}
