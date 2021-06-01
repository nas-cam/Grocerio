using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Account
{
    public interface IAccountService
    {
        GrocerioModels.Users.Account Insert(GrocerioModels.Requests.User.InsertAccountRequest request);
        GrocerioModels.Users.Account Authenticate(string username, string pass);
    }
}
