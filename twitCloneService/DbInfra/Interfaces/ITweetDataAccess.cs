using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twitCloneService.Models;

namespace twitCloneService.DbInfra
{
    public interface ITweetDataAccess
    {
        List<Tweet> GetAllTweets();

        List<Tweet> GetUserTweets(Guid userId);

        Tweet GetTweet(Guid targetId);

        void SaveTweet(Tweet tweet);
    }
}
