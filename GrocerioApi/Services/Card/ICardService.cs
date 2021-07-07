using GrocerioModels.CreditCard;
using GrocerioModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Card
{
    public interface ICardService
    {
        public BoolResponse AddNewCreditCard(int userId, NewCreditCardModel newCreditCard);
        public List<CensoredCardData> GetUsersCreditCards(int userId);
        public CensoredCardData GetCreditCardById(int userId, int cardId);
        public CensoredCardData GetUsersMainCreditCard(int userId);
        public BoolResponse UpdateMainCreditCard(int userId, int cardId);
        public BoolResponse ChangeCardActivity(int userId, int cardId, bool flag);
        public BoolResponse UpdateCreditCard(int userId, int cardId, NewCreditCardModel newCreditCard);
    }
}
