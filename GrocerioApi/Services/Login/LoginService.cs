using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using GrocerioApi.Database.Context;
using GrocerioModels.Enums.User;
using GrocerioModels.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GrocerioApi.Services.Login
{
    public class LoginService : ILoginService
    {

        public readonly GrocerioContext _context;

        public LoginService(GrocerioContext context)
        {
            _context = context;
        }


        public LoginResponse Login(string username)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.Username.ToLower() == username.ToLower());
            if (account == null) return new LoginResponse();

            if (account.Role == Role.Admin)
            {

                var admin = _context.Admins.Include(a => a.Account)
                    .SingleOrDefault(a => a.Account.Username.ToLower() == username.ToLower());
                return new LoginResponse()
                {
                    Role = Convert.ToInt32(admin.Account.Role), 
                    Id = admin.AdminId, 
                    Username = admin.Account.Username, 
                    AccountId =  admin.AccountId
                };
            }
            else
            {
                var user = _context.Users.Include(u => u.Account)
                    .SingleOrDefault(u => u.Account.Username.ToLower() == username.ToLower());
                return new LoginResponse(){
                    Role = Convert.ToInt32(user.Account.Role), 
                    Id =  user.UserId, 
                    Username =  user.Account.Username,
                    AccountId = user.AccountId
                };
            }
        }
    }
}
