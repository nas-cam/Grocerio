using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioApi.Services.User;
using GrocerioModels.Requests.User;
using GrocerioModels.Response;
using GrocerioModels.Response.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace GrocerioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<GrocerioModels.Users.User> Insert([FromBody]GrocerioModels.Requests.User.InsertUserRequest request)
        {
            return Ok(_userService.Insert((request)));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<GrocerioModels.Users.User>> Get([FromQuery]UserSearchRequest request)
        {
            return Ok(_userService.GetUsers(request));
        }

        [HttpGet("GetUserById/{userId}")]
        [Authorize(Roles = "User")]
        public ActionResult<GrocerioModels.Users.User> GetUserById(int userId)
        {
            var response = _userService.GetUserById(userId);
            if (!response.Success) return NotFound(response.User);
            return Ok(response.User);
        }

        [HttpGet("ChangeUserActivity/{userId}/{active}")]
        [Authorize]
        public ActionResult<StringResponse> ChangeUserActivity(int userId, bool active)
        {
            BoolResponse response = _userService.ChangeUserActivity(userId, active);
            if (!response.Success) return NotFound(new StringResponse() {Message = response.Message});
            return Ok(new StringResponse() { Message = response.Message }); 
        }

        [HttpPut("UpdateUser/{userId}")]
        [Authorize(Roles = "User")]
        public ActionResult<EditUserResponse> UpdateUser(int userId, [FromBody]EditUserRequest request)
        {
            var response = _userService.UpdateUser(userId, request);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        [HttpPut("UpdatePassword/{userId}")]
        [Authorize(Roles = "User")]
        public ActionResult<StringResponse> UpdatePassword(int userId, [FromBody]UpdatePasswordRequest request)
        {
            var response = _userService.UpdatePassword(userId, request);
            if (!response.Success) return BadRequest(new StringResponse() {Message = response.Message});
            return Ok(new StringResponse() { Message = response.Message });
        }
    }
}
