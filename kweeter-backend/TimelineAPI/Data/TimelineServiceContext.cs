using Microsoft.EntityFrameworkCore;
using TimelineAPI.Model;

namespace TimelineAPI.Data
{
    public class TimelineServiceContext : DbContext
    {
        public TimelineServiceContext(DbContextOptions<TimelineServiceContext> options) : base(options)
        {
            // Creates the database !! Just for DEMO !! in production code you have to handle it differently!  
            /*this.Database.EnsureCreated();*/
        }

        public DbSet<TimelineTweet> TimelineTweet { get; set; }
    }
}
