using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Services;

namespace Football_Backend_dotNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /user
        [HttpGet]
        public IActionResult GetUserInfo(long id)
        {
            var user = _userService.GetUserInfo(id);
            return Ok(user);
        }
    }
}

