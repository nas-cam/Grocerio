using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioModels.Requests.User;
using GrocerioModels.Response;
using GrocerioModels.Response.User;

namespace GrocerioApi.Services.User
{
    public interface IUserService
    {
        GrocerioModels.Users.User Insert(GrocerioModels.Requests.User.InsertUserRequest request);
        List<GrocerioModels.Users.User> GetUsers(UserSearchRequest request);

        BoolResponse ChangeUserActivity(int userId, bool active);
        UserResponse GetUserById(int userId);
        EditUserResponse UpdateUser(int userId, EditUserRequest request);
        BoolResponse UpdatePassword(int userId, UpdatePasswordRequest request);
        StringResponse HandleLock(bool flag);

    }
}
