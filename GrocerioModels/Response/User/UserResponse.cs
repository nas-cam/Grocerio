using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Response.User
{
    public class UserResponse
    {
        public bool Success { get; set; }
        public GrocerioModels.Users.User User { get; set; }
    }
}
