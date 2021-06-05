using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioApi.Services.User;
using Microsoft.AspNetCore.Authorization;

namespace GrocerioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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



    }
}
