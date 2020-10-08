using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twitCloneService.DbInfra;
using twitCloneService.Models;

namespace twitCloneService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ITweetDataAccess _tweetDataAccess;

        public TweetController(
            ITweetDataAccess tweetDataAccess)
        {
            _tweetDataAccess = tweetDataAccess;
        }

        [HttpPost]
        [Route("createtweet")]
        public async Task<IActionResult> CreateTweet([FromBody] Tweet tweet)
        {
            _tweetDataAccess.SaveTweet(tweet);

            return Ok("success");
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(_tweetDataAccess.GetAllTweets());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("getUserTweets")]
        public async Task<IActionResult> GetuserTweets([FromBody] Guid userId)
        {
            try
            {
                return Ok(_tweetDataAccess.GetUserTweets(userId));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
