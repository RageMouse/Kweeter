using Microsoft.EntityFrameworkCore;
using TweetAPI.Model;

namespace TweetAPI.Data
{
    public class TweetServiceContext : DbContext
    {
        public TweetServiceContext(DbContextOptions<TweetServiceContext> options) : base(options)
        {
            // Creates the database !! Just for DEMO !! in production code you have to handle it differently!  
            this.Database.EnsureCreated();
        }

        public DbSet<Tweet> Tweet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tweet>().HasData(
              new Tweet(1, "Test", "Just work for once"),
              new Tweet(2, "Pls", "I need to feed my family"),
              new Tweet(3, "Bro", "This is going on for too long")
            );
        }
    }
}
