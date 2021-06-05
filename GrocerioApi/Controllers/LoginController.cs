using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioApi.Services.Login;
using GrocerioModels.Login;
using Microsoft.AspNetCore.Authorization;

namespace GrocerioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        public readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("{username}")]
        public ActionResult<LoginResponse> Login(string username)
        {
            return Ok(_loginService.Login(username));
        }


    }
}
