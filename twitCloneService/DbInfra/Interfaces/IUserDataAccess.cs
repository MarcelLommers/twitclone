using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twitCloneService.Models;

namespace twitCloneService.DbInfra
{
    public interface IUserDataAccess
    {
        List<User> GetAllUsers();

        User GetUser(Guid userId);
    }
}
