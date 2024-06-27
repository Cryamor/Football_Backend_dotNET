using System;
using Player.Models;

namespace Player.Data
{
    public interface IPlayerRepository
    {
        void UpdatePlayer(PlayerSimpleInfo player);
        void UpdatePlayerMore(PlayerDetailInfo player);
        void UpdatePlayerDetail(int playerId, PlayerDetailInfo.SeasonInfo detailInfo);
        List<PlayerDetailInfo.SeasonInfo> GetSeasonInfo(int playerId);
        PlayerSimpleInfo GetPlayer(int playerId);
        long Count(string league);
        List<PlayerSimpleInfo> SelectPlayers(int start, int size, string league);
    }
}

