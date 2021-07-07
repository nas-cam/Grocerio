using GrocerioApi.Database.Context;
using GrocerioApi.Services.Notification;
using GrocerioApi.Services.User;
using GrocerioModels.CreditCard;
using GrocerioModels.Enums.Notification;
using GrocerioModels.Response;
using GrocerioModels.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Card
{
    public class CardService : ICardService
    {
        private readonly GrocerioContext _context;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;

        public CardService(GrocerioContext context, INotificationService notificationService, IUserService userService)
        {
            _context = context;
            _notificationService = notificationService;
            _userService = userService;
        }

        #region Private

        private class ValidUser
        {
            public BoolResponse Response { get; set; }
            public Database.Entities.User User { get; set; }
        }

        private ValidUser ValidateUserId(int userId)
        {
            var response = new ValidUser()
            {
                Response = new BoolResponse() { Success = false },
                User = null
            };
            var user = _context.Users.Include(u=>u.CreditCards).SingleOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                response.Response.Message = "Invalid user id";
                return response;
            }

            if (!user.Active)
            {
                response.Response.Message = "The user is currently deactivated";
                return response;
            }

            if (user.Locked)
            {
                response.Response.Message = "The user is currently locked";
                return response;
            }
            response.Response.Success= true;
            response.User = user;
            return response;
        }

        private CensoredCardData CreateCensoredCard(Database.Entities.CreditCard creditCard)
        {
            return new CensoredCardData()
            {
                AddedOn = creditCard.AddedOn,
                CardId = creditCard.Id,
                CardNumber = Format.CreditCardNumber(creditCard.CardNumber),
                Main = creditCard.Main, 
                Active = creditCard.Active
            };
        }

        #endregion

        public BoolResponse AddNewCreditCard(int userId, NewCreditCardModel newCreditCard)
        {

            var response = ValidateUserId(userId);
            if (!response.Response.Success) return response.Response;

            response.User.CreditCards.Add(new Database.Entities.CreditCard()
            {
                AddedOn = Get.CurrentDate(),
                CardHolder = newCreditCard.CardHolder,
                CardNumber = newCreditCard.CardNumber,
                CVV = newCreditCard.CVV,
                Expiration = newCreditCard.Expiration,
                Main = false,
                Active = true
            });

            _context.SaveChanges();
            response.Response.Message = $"A new credit card added in successfully: {Format.CreditCardNumber(newCreditCard.CardNumber)}";
            _notificationService.AddNotification($"A new credit card added in successfully: {Format.CreditCardNumber(newCreditCard.CardNumber)}", NotificationCategory.Success, _userService.GetAccountId(userId));
            return response.Response;
        }

        public List<CensoredCardData> GetUsersCreditCards(int userId)
        {
            var response = ValidateUserId(userId);
            if (!response.Response.Success) return null;

            List<CensoredCardData> usersCards = new List<CensoredCardData>();
            foreach (var card in response.User.CreditCards)
                usersCards.Add(CreateCensoredCard(card));

            return usersCards;
        }

        public CensoredCardData GetCreditCardById(int userId, int cardId)
        {
            var response = ValidateUserId(userId);
            if (!response.Response.Success) return null;

            var creditCard = _context.CreditCards.SingleOrDefault(c=>c.Id == cardId);
            if (creditCard == null || creditCard.UserId != userId) return null;

            return CreateCensoredCard(creditCard);  
        }

        public CensoredCardData GetUsersMainCreditCard(int userId)
        {
            var response = ValidateUserId(userId);
            if (!response.Response.Success) return null;

            return CreateCensoredCard(response.User.CreditCards.Single(c => c.Main));
        }

        public BoolResponse UpdateMainCreditCard(int userId, int cardId)
        {
            var response = ValidateUserId(userId);
            if (!response.Response.Success) return response.Response;

            #region CardValidation
            var creditCard = response.User.CreditCards.SingleOrDefault(c => c.Id == cardId);
            if(creditCard == null)
            {
                response.Response.Success = false;
                response.Response.Message = "Invalid card id";
                return response.Response;
            }
            if(creditCard.UserId != userId)
            {
                response.Response.Success = false;
                response.Response.Message = "The forwarded credit card does not belong to the requested user";
                return response.Response;
            }

            if (creditCard.Main)
            {
                response.Response.Success = false;
                response.Response.Message = "This card is already a main card";
                return response.Response;
            }
            #endregion

            foreach (var card in response.User.CreditCards) card.Main = false;
            creditCard.Main = true;

            _context.SaveChanges();
            response.Response.Message = $"Main credit card: {Format.CreditCardNumber(creditCard.CardNumber)} updated successfully";
            _notificationService.AddNotification($"Main credit card: {Format.CreditCardNumber(creditCard.CardNumber)} updated successfully", NotificationCategory.Success, _userService.GetAccountId(userId));

            return response.Response;
        }

        public BoolResponse ChangeCardActivity(int userId, int cardId, bool flag)
        {
            var response = ValidateUserId(userId);
            if (!response.Response.Success) return response.Response;

            #region CardValidation
            var creditCard = response.User.CreditCards.SingleOrDefault(c => c.Id == cardId);
            if (creditCard == null)
            {
                response.Response.Success = false;
                response.Response.Message = "Invalid card id";
                return response.Response;
            }
            if (creditCard.UserId != userId)
            {
                response.Response.Success = false;
                response.Response.Message = "The forwarded credit card does not belong to the requested user";
                return response.Response;
            }

            if (creditCard.Main && !flag)
            {
                response.Response.Success = false;
                response.Response.Message = "Cannot deactivate the main card";
                return response.Response;
            }

            #endregion

            creditCard.Active = flag;
            _context.SaveChanges();
            if (flag)
            {
                response.Response.Message = $"The credit card {Format.CreditCardNumber(creditCard.CardNumber)} has been activated";
                _notificationService.AddNotification($"The credit card {Format.CreditCardNumber(creditCard.CardNumber)} has been activated", NotificationCategory.Info, _userService.GetAccountId(userId));
            }
            else
            {
                response.Response.Message = $"The credit card {Format.CreditCardNumber(creditCard.CardNumber)} has been deactivated";
                _notificationService.AddNotification($"The credit card {Format.CreditCardNumber(creditCard.CardNumber)} has been deactivated", NotificationCategory.Warning, _userService.GetAccountId(userId));
            }

            return response.Response;
        }

        public BoolResponse UpdateCreditCard(int userId, int cardId, NewCreditCardModel newCreditCard)
        {
            var response = ValidateUserId(userId);
            if (!response.Response.Success) return response.Response;

            #region CardValidation
            var creditCard = response.User.CreditCards.SingleOrDefault(c => c.Id == cardId);
            if (creditCard == null)
            {
                response.Response.Success = false;
                response.Response.Message = "Invalid card id";
                return response.Response;
            }
            if (creditCard.UserId != userId)
            {
                response.Response.Success = false;
                response.Response.Message = "The forwarded credit card does not belong to the requested user";
                return response.Response;
            }

            #endregion

            creditCard.AddedOn = Get.CurrentDate();
            creditCard.CardHolder = newCreditCard.CardHolder;
            creditCard.CardNumber = newCreditCard.CardNumber;
            creditCard.CVV = newCreditCard.CVV;

            _context.SaveChanges();

            response.Response.Message = $"The credit card {Format.CreditCardNumber(creditCard.CardNumber)} has been updated successfully";
            _notificationService.AddNotification($"The credit card {Format.CreditCardNumber(creditCard.CardNumber)} has been updated successfully", NotificationCategory.Success, _userService.GetAccountId(userId));

            return response.Response;
        }
    }
}
