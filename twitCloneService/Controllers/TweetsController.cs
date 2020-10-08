using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using twitCloneService.DbInfra;
using twitCloneService.Models;

namespace twitCloneService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly TweetDbContext _context;

        public TweetsController(TweetDbContext context)
        {
            _context = context;
        }

        // GET: api/Tweets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tweet>>> GetTweets()
        {
            IEnumerable<Tweet> result = _context.Tweets;

            // Order by upload date, starting at the most recent.
            result = result.OrderByDescending(t => t.PostDate);

            return result.ToList();
        }

        // GET: api/Tweets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tweet>> GetTweet(Guid id)
        {
            var tweet = await _context.Tweets.FindAsync(id);

            if (tweet == null)
            {
                return NotFound();
            }

            return tweet;
        }

        [HttpGet]
        [Route("{userId}/getTweets")]
        public async Task<ActionResult<List<Tweet>>> GetUserTweets(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            // Retrieve all tweets posted by the user.
            IEnumerable<Tweet> result = _context.Tweets.Where(t => t.UserId == userId);

            // Order by upload date, starting at the most recent.
            result = result.OrderByDescending(t => t.PostDate);

            return result.ToList();
        }

        // PUT: api/Tweets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTweet(Guid id, Tweet tweet)
        {
            if (id != tweet.Id)
            {
                return BadRequest();
            }

            _context.Entry(tweet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TweetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tweets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tweet>> PostTweet(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTweet", new { id = tweet.Id }, tweet);
        }

        // DELETE: api/Tweets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tweet>> DeleteTweet(Guid id)
        {
            var tweet = await _context.Tweets.FindAsync(id);
            if (tweet == null)
            {
                return NotFound();
            }

            _context.Tweets.Remove(tweet);
            await _context.SaveChangesAsync();

            return tweet;
        }

        private bool TweetExists(Guid id)
        {
            return _context.Tweets.Any(e => e.Id == id);
        }
    }
}
