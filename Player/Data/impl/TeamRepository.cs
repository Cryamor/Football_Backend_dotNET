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

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public void UpdateTeam(TeamSimpleInfo team)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO team (id, name, country, logo, founded, updateTime)
                    VALUES (@Id, @Name, @Country, @Logo, @Founded, NOW())
                    ON DUPLICATE KEY UPDATE
                    name = VALUES(name),
                    country = VALUES(country),
                    logo = VALUES(logo),
                    founded = VALUES(founded),
                    updateTime = NOW();
                ";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", team.Id);
                    cmd.Parameters.AddWithValue("@Name", team.Name);
                    cmd.Parameters.AddWithValue("@Country", team.Country);
                    cmd.Parameters.AddWithValue("@Logo", team.Logo);
                    cmd.Parameters.AddWithValue("@Founded", team.Founded);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTeamDetail(TeamDetailInfo team)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO team (id, name, country, logo, founded, venueName, venueAddress, venueCity, venueImage, venueCapacity, updateTime)
                    VALUES (@Id, @Name, @Country, @Logo, @Founded, @VenueName, @VenueAddress, @VenueCity, @VenueImage, @VenueCapacity, NOW())
                    ON DUPLICATE KEY UPDATE
                    name = VALUES(name),
                    country = VALUES(country),
                    logo = VALUES(logo),
                    founded = VALUES(founded),
                    venueName = VALUES(venueName),
                    venueAddress = VALUES(venueAddress),
                    venueCity = VALUES(venueCity),
                    venueImage = VALUES(venueImage),
                    venueCapacity = VALUES(venueCapacity),
                    updateTime = NOW();
                ";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", team.Id);
                    cmd.Parameters.AddWithValue("@Name", team.Name);
                    cmd.Parameters.AddWithValue("@Country", team.Country);
                    cmd.Parameters.AddWithValue("@Logo", team.Logo);
                    cmd.Parameters.AddWithValue("@Founded", team.Founded);
                    cmd.Parameters.AddWithValue("@VenueName", team.VenueName);
                    cmd.Parameters.AddWithValue("@VenueAddress", team.VenueAddress);
                    cmd.Parameters.AddWithValue("@VenueCity", team.VenueCity);
                    cmd.Parameters.AddWithValue("@VenueImage", team.VenueImage);
                    cmd.Parameters.AddWithValue("@VenueCapacity", team.VenueCapacity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMember(TeamDetailInfo.PlayerInfo player, int teamid)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO player (id, name, age, number, position, photo, teamid, updateTime)
                    VALUES (@Id, @Name, @Age, @Number, @Position, @Photo, @TeamId, NOW())
                    ON DUPLICATE KEY UPDATE
                    id = VALUES(id),
                    name = VALUES(name),
                    age = VALUES(age),
                    number = VALUES(number),
                    position = VALUES(position),
                    photo = VALUES(photo),
                    teamid = VALUES(teamid),
                    updateTime = NOW();
                ";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", player.Id);
                    cmd.Parameters.AddWithValue("@Name", player.Name);
                    cmd.Parameters.AddWithValue("@Age", player.Age);
                    cmd.Parameters.AddWithValue("@Number", player.Number);
                    cmd.Parameters.AddWithValue("@Position", player.Position);
                    cmd.Parameters.AddWithValue("@Photo", player.Photo);
                    cmd.Parameters.AddWithValue("@TeamId", teamid);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public long Count()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM team";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    return Convert.ToInt64(cmd.ExecuteScalar());
                }
            }
        }

        public List<TeamSimpleInfo> SelectTeams(int start, int size)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT id, name, country, logo, founded
                    FROM team
                    LIMIT @Start, @Size
                ";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Start", start);
                    cmd.Parameters.AddWithValue("@Size", size);

                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TeamSimpleInfo> teams = new List<TeamSimpleInfo>();
                        while (reader.Read())
                        {
                            TeamSimpleInfo team = new TeamSimpleInfo();
                            team.Id = reader.GetInt32("id");
                            team.Name = reader.GetString("name");
                            team.Country = reader.GetString("country");
                            team.Logo = reader.GetString("logo");
                            team.Founded = reader.GetString("founded");
                            teams.Add(team);
                        }
                        return teams;
                    }
                }
            }
        }

        public TeamDetailInfo GetTeam(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT id, name, country, logo, founded, venueName, venueAddress, venueCity, venueImage, venueCapacity
                    FROM team
                    WHERE id = @Id
                ";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TeamDetailInfo team = new TeamDetailInfo();
                            team.Id = reader.GetInt32("id");
                            team.Name = reader.GetString("name");
                            team.Country = reader.GetString("country");
                            team.Logo = reader.GetString("logo");
                            team.Founded = reader.GetString("founded");
                            team.VenueName = reader.GetString("venueName");
                            team.VenueAddress = reader.GetString("venueAddress");
                            team.VenueCity = reader.GetString("venueCity");
                            team.VenueImage = reader.GetString("venueImage");
                            team.VenueCapacity = reader.GetInt32("venueCapacity");
                            return team;
                        }
                        return null;
                    }
                }
            }
        }

        public List<TeamDetailInfo.PlayerInfo> GetMember(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT id, name, age, number, position, photo
                    FROM player
                    WHERE teamid = @Id
                ";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TeamDetailInfo.PlayerInfo> members = new List<TeamDetailInfo.PlayerInfo>();
                        while (reader.Read())
                        {
                            TeamDetailInfo.PlayerInfo player = new TeamDetailInfo.PlayerInfo();
                            player.Id = reader.GetInt32("id");
                            player.Name = reader.GetString("name");
                            player.Age = reader.GetInt32("age");
                            player.Number = reader.GetInt32("number");
                            player.Position = reader.GetString("position");
                            player.Photo = reader.GetString("photo");
                            members.Add(player);
                        }
                        return members;
                    }
                }
            }
        }
    }
}

