using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twitCloneService.Models;

namespace twitCloneService.DbInfra
{
    public class TweetDataAccess : ITweetDataAccess
    {
        public List<Tweet> GetAllTweets()
        {
            using (var context = new TweetDbContext())
            {
                return context.Tweets.ToList();
            }
        }

        public List<Tweet> GetUserTweets(Guid userId)
        {
            using (var context = new TweetDbContext())
            {
                // Retrieve all tweets posted by the user.
                IEnumerable<Tweet> result = context.Tweets.Where(t => t.UserId == userId);

                // Order by upload date, starting at the most recent.
                result = result.OrderByDescending(t => t.PostDate);

                return result.ToList();
            }
        }

        public Tweet GetTweet(Guid targetId)
        {
            using (var context = new TweetDbContext())
            {
                return context.Tweets.FirstOrDefault(t => t.Id == targetId);
            }
        }

        public void SaveTweet(Tweet tweet)
        {
            using (var context = new TweetDbContext())
            {
                context.Tweets.Add(tweet);
                context.SaveChanges();
            }
        }
        public void DeleteTweet(Tweet tweet)
        {
            using (var context = new TweetDbContext())
            {
                context.Tweets.Remove(tweet);
                context.SaveChanges();
            }
        }
    }
}
