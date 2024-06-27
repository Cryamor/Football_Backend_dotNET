using System;
using Player.Data;
using Player.Models;

namespace Player.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        private Dictionary<string, int> gameTypeMap = new()
        {
            { "英超", 39 },
            { "西甲", 107 },
            { "意甲", 71 },
            { "德甲", 78 },
            { "法甲", 61 },
            { "中超", 169 }
        };

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public PlayerList GetAllPlayers(int page, int size, string league)
        {
            throw new NotImplementedException();
        }

        public PlayerDetailInfo GetPlayerDetailById(int playerId)
        {
            throw new NotImplementedException();
        }

        public List<PlayerSimpleInfo> GetPlayersByKeywordAndLeague(string searchKey, string leagueName)
        {
            throw new NotImplementedException();
        }
    }
}

