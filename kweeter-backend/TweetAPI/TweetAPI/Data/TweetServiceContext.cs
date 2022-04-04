using Microsoft.EntityFrameworkCore;
using TweetAPI.Model;

namespace TweetAPI.Data
{
    public class TweetServiceContext : DbContext
    {
        public TweetServiceContext(DbContextOptions<TweetServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Tweet> Tweet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tweet>().HasQueryFilter(f => !f.IsDeleted);
        }
    }
}
