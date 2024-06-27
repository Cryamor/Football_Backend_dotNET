using System;
using Player.Models;

namespace Player.Data
{
    public interface ITeamRepository
    {
        void UpdateTeam(TeamSimpleInfo team);
        void UpdateTeamDetail(TeamDetailInfo team);
        void UpdateMember(TeamDetailInfo.PlayerInfo player, int teamid);
        long Count();
        List<TeamSimpleInfo> SelectTeams(int start, int size);
        TeamDetailInfo GetTeam(int id);
        List<TeamDetailInfo.PlayerInfo> GetMember(int id);
    }
}

