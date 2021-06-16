using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GrocerioApi.Database.Context;
using GrocerioApi.Exceptions;
using GrocerioModels.Enums.User;
using GrocerioModels.Requests.User;
using Microsoft.OpenApi.Models;

namespace GrocerioApi.Services.Account
{
    public class AccountService : IAccountService
    {

        public readonly GrocerioContext _context;
        private readonly IMapper _mapper;

        public AccountService(GrocerioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        private static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public GrocerioModels.Users.Account Insert(InsertAccountRequest request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                throw new UserException("Passwords are not matching");
            }
            foreach (var acc in _context.Accounts.ToList())
            {
                if (acc.Username == request.Username) throw new UserException("The username is taken");
            }
            var account = _mapper.Map<Database.Entities.Account>(request);

            account.PasswordSalt = GenerateSalt();
            account.PasswordHash = GenerateHash(account.PasswordSalt, request.Password);

            _context.Accounts.Add(account);
            _context.SaveChanges();

            return _mapper.Map<GrocerioModels.Users.Account>(_mapper.Map<Database.Entities.Account>(account));
        }

        public GrocerioModels.Users.Account Authenticate(string username, string pass)
        {
            var account = _context.Accounts.FirstOrDefault(x => x.Username == username);

            if (account != null)
            {
                if (account.Role == Role.User)
                {
                    var user = _context.Users.Select(x=>new {x.AccountId, x.Active}).Single(u => u.AccountId == account.AccountId);
                    if (!user.Active) return null;
                }

                var newHash = GenerateHash(account.PasswordSalt, pass);

                if (newHash == account.PasswordHash) return _mapper.Map<GrocerioModels.Users.Account>(account);
            }
            return null;
        }

    }
}
