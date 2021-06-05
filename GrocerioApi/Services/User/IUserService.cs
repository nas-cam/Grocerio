using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.User
{
    public interface IUserService
    {
        GrocerioModels.Users.User Insert(GrocerioModels.Requests.User.InsertUserRequest request);
    }
}
