using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using User.Models;

namespace User.Data
{
	public class UserRepository : IUserRepository
	{
        private readonly string _connectionString;
        // = "server=localhost;port=3306;database=football;user=root;password=12345678;";

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("FootballDbConnection");
        }

        public UserEntity GetUserInfo(long id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var user = new UserEntity();
                using (var command = new MySqlCommand("SELECT * FROM User WHERE Id = @id", connection))
                {
                    // 使用参数化查询来防止 SQL 注入
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user.Id = reader.GetInt64("Id");
                            user.Name = reader.GetString("Name");
                            user.Account = reader.GetString("Account");
                            user.Password = reader.GetString("Password");
                            user.Signature = reader.GetString("Signature");
                            user.Score = reader.GetInt32("Score");
                            user.Follow = reader.GetInt32("Follow");
                            user.Fans = reader.GetInt32("Fans");
                            user.Avatar = reader.GetString("Avatar");
                            user.Isbanned = reader.GetBoolean("Isbanned");
                            user.FavoriteLeague = reader.GetString("FavoriteLeague");
                            user.IsFollowing = reader.GetBoolean("IsFollowing");
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                return user;
            }
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var users = new List<UserEntity>();

                using (var command = new MySqlCommand("SELECT * FROM Users", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                    }
                }

                return users;
            }
        }
    }
}

