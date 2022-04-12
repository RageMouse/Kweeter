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
            modelBuilder.Entity<Tweet>().HasQueryFilter(f => !f.IsDeleted);
        }
    }
}
