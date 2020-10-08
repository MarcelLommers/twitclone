using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twitCloneService.Models;

namespace twitCloneService.DbInfra
{
    public class UserDataAccess : IUserDataAccess
    {
        public List<User> GetAllUsers()
        {
            using (var context = new TweetDbContext())
            {
                return context.Users.ToList();
            }
        }

        public User GetUser(Guid userId)
        {
            using (var context = new TweetDbContext())
            {
                return context.Users.FirstOrDefault(u => u.UserId == userId);
            }
        }
    }
}
