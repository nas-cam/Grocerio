using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Requests.User
{
    public class UpdatePasswordRequest
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
