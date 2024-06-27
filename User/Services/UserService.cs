using System;
using User.Data;
using User.Models;

namespace User.Services
{
	public class UserService : IUserService
	{
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserEntity GetUserInfo(long id)
        {
            return _userRepository.GetUserInfo(id);
        }

        public UserEntity? Login(string account, string password)
        {
            return _userRepository.GetUserByAccAndPas(account, password);
        }


    }
}

