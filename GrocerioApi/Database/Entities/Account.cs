using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioApi.Enums;

namespace GrocerioApi.Database.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
    }
}
