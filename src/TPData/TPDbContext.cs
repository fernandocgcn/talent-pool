using TPDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TPData
{
    public class TPDbContext : DbContext
    {
        public TPDbContext(DbContextOptions<TPDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<DeveloperAvailability> DeveloperAvailabilities { get; set; }
        public DbSet<DeveloperWorkingTime> DeveloperWorkingTimes { get; set; }
        public DbSet<DeveloperKnowledge> DeveloperKnowledges { get; set; }
    }
}
