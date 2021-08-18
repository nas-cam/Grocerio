using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GrocerioApi.Database.Context;
using GrocerioApi.Services.Account;
using GrocerioModels.Enums.User;
using GrocerioModels.Requests.User;
using GrocerioModels.Response;
using GrocerioModels.Response.User;
using GrocerioModels.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

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

            _context.CreditCards.Add(new Database.Entities.CreditCard()
            {
                CardHolder = request.MainCreditCard.CardHolder,
                CardNumber = request.MainCreditCard.CardNumber,
                CVV = request.MainCreditCard.CVV,
                Expiration = request.MainCreditCard.Expiration,
                Main = true,
                AddedOn = Get.CurrentDate(),
                UserId = user.UserId,
                Active = true
            });

            _context.SaveChanges();

            return _mapper.Map<GrocerioModels.Users.User>(user);
        }

        public List<GrocerioModels.Users.User> GetUsers(UserSearchRequest request)
        {
            var query = _context.Users.Include(u => u.Account).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.FirstName)) query = query.Where(m => m.FirstName.ToLower().StartsWith(request.FirstName.ToLower()));
            if (!string.IsNullOrWhiteSpace(request.LastName)) query = query.Where(m => m.LastName.ToLower().StartsWith(request.LastName.ToLower()));
            if (!string.IsNullOrWhiteSpace(request.Userneme)) query = query.Where(m => m.Account.Username.ToLower().StartsWith(request.Userneme.ToLower()));

            if (request.Active == Active.IsActive) query = query.Where(m => m.Active);
            if (request.Active == Active.NotActive) query = query.Where(m => !m.Active);

            #region CreditCardData
            var allUsers = _mapper.Map<List<GrocerioModels.Users.User>>(query.OrderBy(u => u.FirstName).ToList());
            var creditCards = _context.CreditCards.Select(x => new { x.Id, x.Main, x.CardNumber, x.UserId, x.AddedOn }).ToList();
            foreach (var user in allUsers) {
                var mainCreditCard = creditCards.Single(c => c.UserId == user.UserId && c.Main);
                user.MainCreditCard = new GrocerioModels.CreditCard.CensoredCardData()
                {
                    CardId = mainCreditCard.Id, 
                    Main = mainCreditCard.Main,
                    CardNumber = Format.CreditCardNumber(mainCreditCard.CardNumber), 
                    AddedOn = mainCreditCard.AddedOn
                };
            }
            #endregion

            return allUsers;
        }

        public BoolResponse ChangeUserActivity(int userId, bool active)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return new BoolResponse()
                {
                    Success = false,
                    Message = "Invalid user identifier"
                };
            }

            user.Active = active;
            _context.SaveChanges();
            return new BoolResponse()
            {
                Success = true,
                Message = $"{user.FirstName}'s activity updated successfully to {active.ToString().ToLower()}"
            };
        }

        public UserResponse GetUserById(int userId)
        {
            var dbUser = _context.Users.Include(u => u.Account).SingleOrDefault(u => u.UserId == userId);
            if (dbUser == null) return new UserResponse() {Success = false, User = new GrocerioModels.Users.User()};

            var user = _mapper.Map<GrocerioModels.Users.User>(dbUser);
            var mainCreditCard = _context.CreditCards
                                .Select(x=>new { x.Id, x.UserId, x.Main, x.CardNumber, x.AddedOn, x.Expiration, x.CVV, x.CardHolder})
                                .Single(c => c.UserId == user.UserId && c.Main);

            user.MainCreditCard = new GrocerioModels.CreditCard.CensoredCardData()
            {
                Main = mainCreditCard.Main,
                CardId = mainCreditCard.Id,
                Expiration = mainCreditCard.Expiration,
                CVV = mainCreditCard.CVV,
                CardHolder = mainCreditCard.CardHolder,
                CardNumber = Format.CreditCardNumber(mainCreditCard.CardNumber),
                AddedOn = mainCreditCard.AddedOn
            };

            return new UserResponse()
            {
                Success = true,
                User = user
            };
        }

        public EditUserResponse UpdateUser(int userId, EditUserRequest request)
        {
            var user = _context.Users.Include(u => u.Account).SingleOrDefault(u => u.UserId == userId);
            if (user == null) return new EditUserResponse() { Success = false, User = new GrocerioModels.Users.User(), Message = "Invalid user identifier"};

            if (!string.IsNullOrWhiteSpace(request.Username))
            {
                var allUsernameObjects = _context.Accounts.Select(x => new {x.AccountId, x.Username})
                    .Where(a => a.AccountId != user.AccountId).ToList();

                if (allUsernameObjects.Where(o=>o.Username.ToLower() == request.Username.ToLower()).ToList().Count != 0)
                {
                    return new EditUserResponse() { Success = false, User = new GrocerioModels.Users.User(), Message = "Username already taken" };
                }
                user.Account.Username = request.Username;
            }

            if (!string.IsNullOrWhiteSpace(request.Mail)) user.Mail = request.Mail;
            if (!string.IsNullOrWhiteSpace(request.FirstName)) user.FirstName = request.FirstName;
            if (!string.IsNullOrWhiteSpace(request.LastName)) user.LastName = request.LastName;
            if (!string.IsNullOrWhiteSpace(request.PhoneNumber)) user.PhoneNumber = request.PhoneNumber;
            if (!string.IsNullOrWhiteSpace(request.Address)) user.Address = request.Address;
            if (!string.IsNullOrWhiteSpace(request.ImageLink)) user.ImageLink = request.ImageLink;
            if (request.BirthDate != new DateTime(0001, 1, 1)) user.BirthDate = request.BirthDate;

            _context.SaveChanges();
            return new EditUserResponse()
            {
                User = _mapper.Map<GrocerioModels.Users.User>(user),
                Success = true,
                Message = "User updated successfully"
            };
        }

        public BoolResponse UpdatePassword(int userId, UpdatePasswordRequest request)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return new BoolResponse()
                {
                    Success = false,
                    Message = "Invalid user identifier"
                };
            }

            if (request.Password != request.ConfirmPassword)
            {
                return new BoolResponse()
                {
                    Success = false,
                    Message = "Passwords didn't match"
                };
            }

            user.Account.PasswordSalt = GenerateSalt();
            user.Account.PasswordHash = GenerateHash(user.Account.PasswordSalt, request.Password);
            _context.SaveChanges();

            return new BoolResponse()
            {
                Message = "Password updated successfully",
                Success = true
            };
        }

        public StringResponse HandleLock(bool flag)
        {
            var allUsers = _context.Users.ToList();
            foreach (var user in allUsers) user.Locked = flag;
            _context.SaveChanges();
            return new StringResponse() {Message = flag ? "All users have been locked" : "All users have been unlocked"};
        }

        public GrocerioModels.Users.UserValidation GetUserValidationParams(int userId)
        {

            var user = _context.Users.Select(x => new { Id = x.UserId, x.Active, x.Locked }).SingleOrDefault(u => u.Id == userId);
            if (user == null || !user.Active) return null;
            return new GrocerioModels.Users.UserValidation()
            {
                Active = user.Active, 
                Locked = user.Locked
            };
        }

        public int GetAccountId(int userId)
        {
            return _context.Users.Single(u => u.UserId == userId).AccountId;
        }
    }
}
