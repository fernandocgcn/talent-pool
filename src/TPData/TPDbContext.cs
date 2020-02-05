using TPDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TPData
{
    public class TPDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-46J36AR;Database=TalentPoolDb;User ID=sa; Password=sa;MultipleActiveResultSets=true;");
        }

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
