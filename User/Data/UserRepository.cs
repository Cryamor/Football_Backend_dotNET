using System;
using User.Models;

namespace User.Data
{
	public class UserRepository : IUserRepository
	{
        //private readonly UserDbContext _context;

        //public UserRepository(UserDbContext context)
        //{
        //    _context = context;
        //}

        public UserEntity GetUserInfo(long id)
        {
            var res = new UserEntity(1, "1");
            return res;
            //return _context.Users.Find(id);
        }
    }
}

