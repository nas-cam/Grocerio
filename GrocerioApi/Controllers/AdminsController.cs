using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrocerioApi.Services.Admin;
using Microsoft.AspNetCore.Authorization;

namespace GrocerioApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _service;
        public AdminsController(IAdminService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<GrocerioModels.Users.Admin> Insert([FromBody]GrocerioModels.Requests.User.InsertAdminRequest request)
        {
            return Ok(_service.Insert(request));
        }
    }
}
