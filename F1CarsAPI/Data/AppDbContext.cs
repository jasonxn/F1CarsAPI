using Microsoft.EntityFrameworkCore;
using F1CarsAPI.Models;
namespace F1CarsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Team)
                .WithMany(t => t.Cars)
                .HasForeignKey(c => c.teamId);
        }
    }
}
