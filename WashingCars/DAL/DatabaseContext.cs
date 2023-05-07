using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WashingCars.DAL.Entities;

namespace WashingCars.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetail> VehicleDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
