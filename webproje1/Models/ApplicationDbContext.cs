using Microsoft.EntityFrameworkCore;

namespace webproje1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ekmek> Ekmekler { get; set; }
        public DbSet<Recel> Receller { get; set; } 
        public DbSet<Yelek> Yelekler { get; set; } 
        public DbSet<Baharat> Baharatlar { get; set; } 
        public DbSet<Yag> Yaglar { get; set; } 

    }
}
