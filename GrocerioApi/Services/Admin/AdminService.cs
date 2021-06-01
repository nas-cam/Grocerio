using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GrocerioApi.Database.Context;
using GrocerioApi.Services.Account;
using GrocerioModels.Requests.User;

namespace GrocerioApi.Services.Admin
{
    public class AdminService : IAdminService
    {
        public readonly GrocerioContext _context;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public AdminService(GrocerioContext context, IAccountService accountService, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _accountService = accountService;
        }

        public GrocerioModels.Users.Admin Insert(InsertAdminRequest request)
        {

            var admin = _mapper.Map<Database.Entities.Admin>(request);

            request.Role = Role.Admin;
            var accountId = _accountService.Insert(request).AccountId;

            admin.AccountId = accountId;

            _context.Admins.Add(admin);
            _context.SaveChanges();

            return _mapper.Map<GrocerioModels.Users.Admin>(admin);
        }
    }
}
