using System;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using Player.Models;
using static Mysqlx.Crud.UpdateOperation.Types;

namespace Player.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly string _connectionString;

        public PlayerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GamesDbConnection");
        }

        public long Count(string league)
        {
            throw new NotImplementedException();
        }

        public PlayerSimpleInfo GetPlayer(int playerId)
        {
            throw new NotImplementedException();
        }

        public List<PlayerDetailInfo.SeasonInfo> GetSeasonInfo(int playerId)
        {
            throw new NotImplementedException();
        }

        public List<PlayerSimpleInfo> SelectPlayers(int start, int size, string league)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayer(PlayerSimpleInfo player)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayerDetail(int playerId, PlayerDetailInfo.SeasonInfo detailInfo)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayerMore(PlayerDetailInfo player)
        {
            throw new NotImplementedException();
        }
    }
}