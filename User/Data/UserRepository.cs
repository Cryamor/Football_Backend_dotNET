using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using User.Models;

namespace User.Data
{
	public class UserRepository : IUserRepository
	{
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("FootballUserDbConnection");
        }

        public void CopyUserEntity(UserEntity user, MySqlDataReader reader)
        {
            user.Id = reader.IsDBNull(reader.GetOrdinal("_id")) ? 0 : reader.GetInt64("_id");
            user.Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString("Name");
            user.Account = reader.IsDBNull(reader.GetOrdinal("Account")) ? string.Empty : reader.GetString("Account");
            user.Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? string.Empty : reader.GetString("Password");
            user.Signature = reader.IsDBNull(reader.GetOrdinal("Signature")) ? string.Empty : reader.GetString("Signature");
            user.Score = reader.IsDBNull(reader.GetOrdinal("Score")) ? 0 : reader.GetInt32("Score");
            user.Follow = reader.IsDBNull(reader.GetOrdinal("Follow")) ? 0 : reader.GetInt32("Follow");
            user.Fans = reader.IsDBNull(reader.GetOrdinal("Fans")) ? 0 : reader.GetInt32("Fans");
            user.Avatar = reader.IsDBNull(reader.GetOrdinal("Avatar")) ? string.Empty : reader.GetString("Avatar");
            user.Isbanned = reader.IsDBNull(reader.GetOrdinal("Isbanned")) ? false : reader.GetBoolean("Isbanned");
            user.FavoriteLeague = reader.IsDBNull(reader.GetOrdinal("favorite_league")) ? string.Empty : reader.GetString("favorite_league");
            user.CreateDate = reader.IsDBNull(reader.GetOrdinal("createdate")) ? DateTime.MinValue : reader.GetDateTime("createdate");
        }

        public UserEntity? GetUserInfo(long id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var user = new UserEntity();
                using (var command = new MySqlCommand("SELECT * FROM user WHERE _id = @id", connection))
                {
                    // 使用参数化查询来防止 SQL 注入
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CopyUserEntity(user, reader);
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

        public UserEntity? GetUserByAccAndPas(string account, string password)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var user = new UserEntity();
                using (var command = new MySqlCommand("SELECT * FROM user WHERE account = @acc AND password = @pas", connection))
                {
                    command.Parameters.AddWithValue("@acc", account);
                    command.Parameters.AddWithValue("@pas", password);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CopyUserEntity(user, reader);
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

