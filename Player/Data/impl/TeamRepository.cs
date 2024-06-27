using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Player.Models;

namespace Player.Data
{
    public class TeamRepository : ITeamRepository
    {
        private readonly string _connectionString;

        public TeamRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GamesDbConnection");
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public List<TeamDetailInfo.PlayerInfo> GetMember(int id)
        {
            throw new NotImplementedException();
        }

        public TeamDetailInfo GetTeam(int id)
        {
            throw new NotImplementedException();
        }

        public List<TeamSimpleInfo> SelectTeams(int start, int size)
        {
            throw new NotImplementedException();
        }

        public void UpdateMember(TeamDetailInfo.PlayerInfo player, int teamid)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(TeamSimpleInfo team)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeamDetail(TeamDetailInfo team)
        {
            throw new NotImplementedException();
        }
    }
}