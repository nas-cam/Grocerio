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
            var response = _loginService.Login(username);
            if (response.Username == null) return NotFound(response);
            return Ok(response);
        }


    }
}
