using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class CoreDbContext : DbContext
    {
        public DbSet<AppUser> User { get; set; }
        public DbSet<Make> Make { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeatureVehicle>()
                .HasKey(x => new { x.FeatureId, x.VehicleId });
        }

    }
}