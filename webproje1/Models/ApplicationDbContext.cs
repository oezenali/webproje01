using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace webproje1.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Feedback> Feedbackler {  get; set; }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Ekmek> Ekmekler { get; set; }
        public DbSet<Recel> Receller { get; set; }
        public DbSet<Yelek> Yelekler { get; set; }
        public DbSet<Baharat> Baharatlar { get; set; }
        public DbSet<Yag> Yaglar { get; set; }
    }
}
