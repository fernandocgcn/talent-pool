using TPDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace TPDomain.Data
{
    public class TPDbContext : DbContext
    {
        public TPDbContext(DbContextOptions<TPDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
        }

        public DbSet<Availability> Availabilities { get; set; }
    }
}
