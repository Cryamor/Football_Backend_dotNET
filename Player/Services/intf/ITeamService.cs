using System;
using Player.Models;

namespace Player.Services
{
    public interface ITeamService
    {
        List<TeamSimpleInfo> GetTeamsByKeyword(string searchKey);

        TeamList GetAllTeams(int page, int size);

        TeamDetailInfo GetTeamDetailById(int id);
    }
}

