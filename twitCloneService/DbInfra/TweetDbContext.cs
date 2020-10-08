using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twitCloneService.Models;

namespace twitCloneService.DbInfra
{
    public class TweetDbContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }

        public TweetDbContext()
        {
        }

        public TweetDbContext(DbContextOptions
            <TweetDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=TwitDB;Integrated Security=True");
        }
    }
}
