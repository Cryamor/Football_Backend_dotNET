using System;
using Player.Models;

namespace Player.Services
{
    public interface IGameService
    {
        GameList GetAllGames(int page, int size, string league);
        List<GameSimpleInfo> GetGamesByDateAndLeague(string date, string leagueName);
        GameDetailInfo GetGameDetailById(int id);
    }
}

