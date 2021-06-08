using System;
using System.Collections.Generic;
using System.Text;
using GrocerioModels.Enums.User;

namespace GrocerioModels.Requests.User
{
    public class UserSearchRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Userneme { get; set; }
        public Active Active { get; set; }
    }
}
