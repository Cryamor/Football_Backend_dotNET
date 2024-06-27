using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football_Backend_dotNET.Models;
using Microsoft.AspNetCore.Mvc;
using Player.Services;

namespace Football_Backend_dotNET.Controllers
{
    [ApiController]
    [Route("api/player")]
    public class SearchPlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly ILogger<SearchPlayerController> _logger;

        public SearchPlayerController(IPlayerService playerService, ILogger<SearchPlayerController> logger)
        {
            _playerService = playerService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Result> GetAllPlayers([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string league = "全部赛事")
        {
            var players = _playerService.GetAllPlayers(page, size, league);
            return Ok(Result.Success(players));
        }

        [HttpGet("info")]
        public ActionResult<Result> GetPlayersByKeywordAndLeague([FromQuery] string searchKey, [FromQuery] string leagueName)
        {
            var players = _playerService.GetPlayersByKeywordAndLeague(searchKey, leagueName);
            return Ok(Result.Success(players));
        }

        [HttpGet("detail")]
        public ActionResult<Result> GetPlayerDetailById([FromQuery] int playerId)
        {
            var playerDetail = _playerService.GetPlayerDetailById(playerId);
            return Ok(Result.Success(playerDetail));
        }
    }

}

