using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Response.User
{
    public class EditUserResponse
    {
        public bool Success { get; set; }
        public GrocerioModels.Users.User User { get; set; }
        public string Message { get; set; }
    }
}
