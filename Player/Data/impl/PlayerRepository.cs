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

        public void UpdatePlayer(PlayerSimpleInfo player)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                    INSERT INTO player (id, name, league, firstName, lastName, age, height, weight, country, photo, birth, updateTime)
                    VALUES (@id, @name, @league, @firstName, @lastName, @age, @height, @weight, @country, @photo, @birth, NOW())
                    ON DUPLICATE KEY UPDATE
                    name = VALUES(name),
                    league = VALUES(league),
                    firstName = VALUES(firstName),
                    lastName = VALUES(lastName),
                    age = VALUES(age),
                    height = VALUES(height),
                    weight = VALUES(weight),
                    country = VALUES(country),
                    photo = VALUES(photo),
                    birth = VALUES(birth),
                    updateTime = NOW();";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", player.Id);
                    command.Parameters.AddWithValue("@name", player.Name);
                    command.Parameters.AddWithValue("@league", player.League);
                    command.Parameters.AddWithValue("@firstName", player.FirstName);
                    command.Parameters.AddWithValue("@lastName", player.LastName);
                    command.Parameters.AddWithValue("@age", player.Age);
                    command.Parameters.AddWithValue("@height", player.Height);
                    command.Parameters.AddWithValue("@weight", player.Weight);
                    command.Parameters.AddWithValue("@country", player.Country);
                    command.Parameters.AddWithValue("@photo", player.Photo);
                    command.Parameters.AddWithValue("@birth", player.Birth);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePlayerMore(PlayerDetailInfo player)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                    INSERT INTO player (id, name, firstName, lastName, age, height, weight, country, photo, birth, updateTime)
                    VALUES (@id, @name, @firstName, @lastName, @age, @height, @weight, @country, @photo, @birth, NOW())
                    ON DUPLICATE KEY UPDATE
                    name = VALUES(name),
                    firstName = VALUES(firstName),
                    lastName = VALUES(lastName),
                    age = VALUES(age),
                    height = VALUES(height),
                    weight = VALUES(weight),
                    country = VALUES(country),
                    photo = VALUES(photo),
                    birth = VALUES(birth),
                    updateTime = NOW();";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", player.Id);
                    command.Parameters.AddWithValue("@name", player.Name);
                    command.Parameters.AddWithValue("@firstName", player.FirstName);
                    command.Parameters.AddWithValue("@lastName", player.LastName);
                    command.Parameters.AddWithValue("@age", player.Age);
                    command.Parameters.AddWithValue("@height", player.Height);
                    command.Parameters.AddWithValue("@weight", player.Weight);
                    command.Parameters.AddWithValue("@country", player.Country);
                    command.Parameters.AddWithValue("@photo", player.Photo);
                    command.Parameters.AddWithValue("@birth", player.Birth);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePlayerDetail(int playerId, PlayerDetailInfo.SeasonInfo detailInfo)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                    INSERT INTO seasonInfo (playerid, seasonNum, teamName, leagueName, leagueLogo, position, goals, assists, passes, tackles, yellow, red, updateTime)
                    VALUES (@playerId, @seasonNum, @teamName, @leagueName, @leagueLogo, @position, @goals, @assists, @passes, @tackles, @yellow, @red, NOW())
                    ON DUPLICATE KEY UPDATE
                    playerid = VALUES(playerid),
                    seasonNum = VALUES(seasonNum),
                    teamName = VALUES(teamName),
                    leagueName = VALUES(leagueName),
                    leagueLogo = VALUES(leagueLogo),
                    position = VALUES(position),
                    goals = VALUES(goals),
                    assists = VALUES(assists),
                    passes = VALUES(passes),
                    tackles = VALUES(tackles),
                    yellow = VALUES(yellow),
                    red = VALUES(red),
                    updateTime = NOW();";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@playerId", playerId);
                    command.Parameters.AddWithValue("@seasonNum", detailInfo.SeasonNum);
                    command.Parameters.AddWithValue("@teamName", detailInfo.TeamName);
                    command.Parameters.AddWithValue("@leagueName", detailInfo.LeagueName);
                    command.Parameters.AddWithValue("@leagueLogo", detailInfo.LeagueLogo);
                    command.Parameters.AddWithValue("@position", detailInfo.Position);
                    command.Parameters.AddWithValue("@goals", detailInfo.Goals);
                    command.Parameters.AddWithValue("@assists", detailInfo.Assists);
                    command.Parameters.AddWithValue("@passes", detailInfo.Passes);
                    command.Parameters.AddWithValue("@tackles", detailInfo.Tackles);
                    command.Parameters.AddWithValue("@yellow", detailInfo.Yellow);
                    command.Parameters.AddWithValue("@red", detailInfo.Red);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<PlayerDetailInfo.SeasonInfo> GetSeasonInfo(int playerId)
        {
            var seasonInfos = new List<PlayerDetailInfo.SeasonInfo>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                    SELECT * FROM seasonInfo
                    WHERE playerid = @playerId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@playerId", playerId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var seasonInfo = new PlayerDetailInfo.SeasonInfo
                            {
                                PlayerId = reader.GetInt32("playerid"),
                                SeasonNum = reader.GetInt32("seasonNum"),
                                TeamName = reader.GetString("teamName"),
                                LeagueName = reader.GetString("leagueName"),
                                LeagueLogo = reader.GetString("leagueLogo"),
                                Position = reader.GetString("position"),
                                Goals = reader.GetInt32("goals"),
                                Assists = reader.GetInt32("assists"),
                                Passes = reader.GetInt32("passes"),
                                Tackles = reader.GetInt32("tackles"),
                                Yellow = reader.GetInt32("yellow"),
                                Red = reader.GetInt32("red"),
                                UpdateTime = reader.GetDateTime("updateTime")
                            };
                            seasonInfos.Add(seasonInfo);
                        }
                    }
                }
            }
            return seasonInfos;
        }

        public PlayerSimpleInfo GetPlayer(int playerId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                    SELECT * FROM player
                    WHERE id = @playerId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@playerId", playerId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PlayerSimpleInfo
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                League = reader.GetString("league"),
                                FirstName = reader.GetString("firstName"),
                                LastName = reader.GetString("lastName"),
                                Age = reader.GetInt32("age"),
                                Height = reader.GetString("height"),
                                Weight = reader.GetString("weight"),
                                Country = reader.GetString("country"),
                                Photo = reader.GetString("photo"),
                                Birth = reader.GetString("birth"),
                            };
                        }
                    }
                }
            }
            return null;
        }

        public long Count(string league)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                    SELECT count(*) FROM player
                    WHERE (@league IS NULL OR @league = '' OR @league = '全部赛事' OR league LIKE CONCAT('%', @league, '%'))";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@league", string.IsNullOrEmpty(league) || league == "全部赛事" ? (object)DBNull.Value : league);
                    return (long)command.ExecuteScalar();
                }
            }
        }

        public List<PlayerSimpleInfo> SelectPlayers(int start, int size, string league)
        {
            var players = new List<PlayerSimpleInfo>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                SELECT id, name, league, firstName, lastName, age, height, weight, country, photo
                FROM player
                WHERE (@league IS NULL OR @league = '' OR @league = '全部赛事' OR league LIKE CONCAT('%', @league, '%'))
                LIMIT @start, @size";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@start", start);
                    command.Parameters.AddWithValue("@size", size);
                    command.Parameters.AddWithValue("@league", string.IsNullOrEmpty(league) || league == "全部赛事" ? (object)DBNull.Value : league);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var player = new PlayerSimpleInfo
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                League = reader.GetString("league"),
                                FirstName = reader.GetString("firstName"),
                                LastName = reader.GetString("lastName"),
                                Age = reader.GetInt32("age"),
                                Height = reader.GetString("height"),
                                Weight = reader.GetString("weight"),
                                Country = reader.GetString("country"),
                                Photo = reader.GetString("photo")
                            };
                            players.Add(player);
                        }
                    }
                }
            }
            return players;
        }
    }
}