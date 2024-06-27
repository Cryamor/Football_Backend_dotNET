using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Services;
using Football_Backend_dotNET.Models;
using Football_Backend_dotNET.Utils;

namespace Football_Backend_dotNET.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtUtils jwtUtils;

        public UserController(IUserService userService, JwtUtils jwtUtils)
        {
            _userService = userService;
            this.jwtUtils = jwtUtils;
        }

        [HttpPost("/login")]
        public Result Login(string account, string password)
        {
            var user = _userService.Login(account, password);
            if (user != null)
            {
                Dictionary<string, object> claims = new()
                {
                    { "id", user.Id },
                    { "account", user.Account }
                };
                string jwt = jwtUtils.CreateJwt(claims);
                Dictionary<string, object> responseData = new()
                {
                    { "jwt", jwt },
                    { "favoriteLeague", user.FavoriteLeague },
                    { "id", user.Id }
                };
                return Result.Success(responseData);
            }
            else
                return Result.Error("userError");
        }

        [HttpPost("/register")]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost("/check-in")]
        public Result CheckIn()
        {
            // 签到交互即证明今日未签到 前端会通过getCheckDays来获取签到过的天数 从而自己判断是否签到过
            var userId = jwtUtils.GetUserIdFromToken(Request);
            return Result.Success(userId);
        }

        [HttpPost("/subscribe-game")]
        public IActionResult FollowGame(long userId, long gameId, string startTime)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser(string? name, string? signature, string? email)
        {
            return Ok();
        }

        [HttpPut("/password")]
        public IActionResult ChangePassword(string oriPassword, string newPassword)
        {
            return Ok();
        }

        [HttpPut("/ban-status")]
        public IActionResult UpdateBanStatus(long id)
        {
            return Ok();
        }

        [HttpPut("/favorite-league")]
        public IActionResult UpdateLeague(string league)
        {
            return Ok();
        }


        [HttpGet("/user-info")]
        public Result GetUserInfo(long id)
        {
            var user = _userService.GetUserInfo(id);
            if (user != null)
            {
                return Result.Success(user);
            }
            else
            {
                return Result.Error("User Not Found!");
            }
        }

        [HttpGet("/user-detail")]
        public IActionResult GetUserDetail()
        {
            return Ok();
        }

        [HttpGet("/login-status")]
        public IActionResult LoginStatus()
        {
            return Ok();
        }

        [HttpGet("/check-days")]
        public ActionResult GetCheckDays()
        {
            return Ok();
        }

        [HttpGet("/posts")]
        public ActionResult GetMyPosts()
        {
            return Ok();
        }

        [HttpGet("/follow-list")]
        public ActionResult GetFollowList()
        {
            return Ok();
        }

        [HttpGet("/fans-list")]
        public ActionResult GetFansList()
        {
            return Ok();
        }

        [HttpGet("/notifications")]
        public ActionResult GetNotifications()
        {
            return Ok();
        }

        [HttpGet()]
        public ActionResult GetALlUsers()
        {
            return Ok();
        }

        [HttpGet("/banned")]
        public ActionResult GetBannedUsers()
        {
            return Ok();
        }

        [HttpGet("/upcoming-games")]
        public ActionResult GetUpcomingGames()
        {

            return Ok();
        }

        [HttpGet("/completed-games")]
        public ActionResult GetCompletedGames()
        {
            return Ok();
        }


        [HttpDelete("/follow/{deleteId}")]
        public ActionResult DeleteFollow(long deleteId)
        {
            return Ok();
        }

    }
}

