using CloudinaryForo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudinaryForo.Database
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {

            base.OnModelCreating(builder);

        }

        public DbSet<ImageEntity> Images { get; set; }

    }
}
