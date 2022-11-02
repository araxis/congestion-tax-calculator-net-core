using congestion.calculator;
using Microsoft.EntityFrameworkCore;

namespace Congestion.Infrastructure
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AppDb");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<City> Cities { get; set; } 
        public DbSet<CongestionTollConfigs> CongestionTollConfigs { get; set; }
    }
}