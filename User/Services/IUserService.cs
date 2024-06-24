using System;
using User.Models;

namespace User.Services
{
	public interface IUserService
	{
        UserEntity GetUserInfo(long id);
    }
}

