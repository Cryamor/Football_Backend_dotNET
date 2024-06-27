using System;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using User.Models;

namespace User.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlSugarClient _db;

        public UserRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("FootballUserDbConnection");
            _db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
        }

        public UserEntity? GetUserInfo(long id)
        {
            return _db.Queryable<UserEntity>().InSingle(id);
        }

        public UserEntity? GetUserByAccAndPas(string account, string password)
        {
            return _db.Queryable<UserEntity>().First(u => u.Account == account && u.Password == password);
        }
    }
}