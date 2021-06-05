using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioModels.Login;

namespace GrocerioApi.Services.Login
{
    public interface ILoginService
    {
        public LoginResponse Login(string username);
    }
}
