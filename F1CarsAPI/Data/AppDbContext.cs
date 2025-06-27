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
                .HasForeignKey(c => c.TeamId);
        }

        //auto-sets CreatedAt and UpdatedAt insted of doing it in controller.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Team || e.Entity is Car);

            var now = DateTimeOffset.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
