using System.Collections.Generic;
using User.Models;

namespace User.Data
{
    public interface IUserRepository
    {
        UserEntity GetUserInfo(long id);
    }
}