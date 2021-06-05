using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GrocerioApi.Database.Context;
using GrocerioApi.Services.Account;
using GrocerioModels.Requests.User;

namespace GrocerioApi.Services.User
{
    public class UserService : IUserService
    {
        public readonly GrocerioContext _context;
        public readonly IAccountService _accountService;
        public readonly IMapper _mapper;

        public UserService(GrocerioContext context, IMapper mapper, IAccountService accountService)
        {
            _context = context;
            _mapper = mapper;
            _accountService = accountService;
        }

        public GrocerioModels.Users.User Insert(InsertUserRequest request)
        {
            var user = _mapper.Map<Database.Entities.User>(request);

            request.Role = Role.User;
            var accountId = _accountService.Insert(request).AccountId;

            user.AccountId = accountId;
            user.Locked = false;
            user.Active = true;

            _context.Users.Add(user);
            _context.SaveChanges();

            return _mapper.Map<GrocerioModels.Users.User>(user);
        }
    }
}
