using FollowerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FollowerAPI.Data
{
    public class DbServiceContext : DbContext
    {
        public DbServiceContext(DbContextOptions<DbServiceContext> options) : base(options)
        {
            // Creates the database !! Just for DEMO !! in production code you have to handle it differently!  
            this.Database.EnsureCreated();
        }

        public DbSet<Follow> Follow { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
