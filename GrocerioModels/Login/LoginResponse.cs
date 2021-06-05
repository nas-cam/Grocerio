using System;
using System.Collections.Generic;
using System.Text;
using GrocerioModels.Requests.User;

namespace GrocerioModels.Login
{
    public class LoginResponse
    {
        public string Username { get; set; }
        public int Role { get; set; }
        public int Id { get; set; }
        public int AccountId { get; set; }
    }
}
