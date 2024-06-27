using System;
using User.Models;

namespace User.Services
{
	public interface IUserService
	{
        UserEntity GetUserInfo(long id);
        UserEntity? Login(string account, string password);


    }
}

