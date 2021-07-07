using GrocerioApi.Services.Card;
using GrocerioModels.CreditCard;
using GrocerioModels.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost("AddNewCreditCard/{userId}")]
        public ActionResult<StringResponse> AddNewCreditCard([FromBody]NewCreditCardModel newCreditCard,  int userId)
        {
            var response = _cardService.AddNewCreditCard(userId, newCreditCard);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            else return Ok(new StringResponse() { Message = response.Message });
        }

        [HttpGet("GetUsersCreditCards/{userId}")]
        public ActionResult<StringResponse> GetUsersCreditCards(int userId)
        {
            var response = _cardService.GetUsersCreditCards(userId);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid user id" });
            else return Ok(response);
        }

        [HttpGet("GetCreditCardById/{userId}/{cardId}")]
        public ActionResult<StringResponse> GetUsersCreditCards(int userId, int cardId)
        {
            var response = _cardService.GetCreditCardById(userId, cardId);
            if (response == null) return NotFound(new StringResponse() { Message = "Identifiers missmatch" });
            else return Ok(response);
        }

        [HttpGet("GetUsersMainCreditCard/{userId}")]
        public ActionResult<StringResponse> GetUsersMainCreditCard(int userId)
        {
            var response = _cardService.GetUsersMainCreditCard(userId);
            if (response == null) return NotFound(new StringResponse() { Message = "Invalid user id" });
            else return Ok(response);
        }

        [HttpPost("UpdateMainCreditCard/{userId}/{cardId}")]
        public ActionResult<StringResponse> UpdateMainCreditCard(int userId, int cardId)
        {
            var response = _cardService.UpdateMainCreditCard(userId, cardId);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            else return Ok(new StringResponse() { Message = response.Message });
        }

        [HttpPost("ChangeCardActivity/{userId}/{cardId}/{flag}")]
        public ActionResult<StringResponse> ChangeCardActivity(int userId, int cardId, bool flag)
        {
            var response = _cardService.ChangeCardActivity(userId, cardId, flag);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            else return Ok(new StringResponse() { Message = response.Message });
        }

        [HttpPost("UpdateCreditCard/{userId}/{cardId}")]
        public ActionResult<StringResponse> UpdateCreditCard(int userId, int cardId, [FromBody]NewCreditCardModel creditCardData)
        {
            var response = _cardService.UpdateCreditCard(userId, cardId, creditCardData);
            if (!response.Success) return BadRequest(new StringResponse() { Message = response.Message });
            else return Ok(new StringResponse() { Message = response.Message });
        }
    }
}
