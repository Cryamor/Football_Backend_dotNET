using System;
using Player.Models;

namespace Player.Services
{
    public interface IPlayerService
    {
        List<PlayerSimpleInfo> GetPlayersByKeywordAndLeague(string searchKey, string leagueName);

        PlayerList GetAllPlayers(int page, int size, string league);

        PlayerDetailInfo GetPlayerDetailById(int playerId);
    }
}

