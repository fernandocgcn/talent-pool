using TPDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace TPDomain.Data
{
    public class TPDbContext : DbContext
    {
        public TPDbContext(DbContextOptions<TPDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>()
                .HasIndex(d => d.Email)
                .IsUnique();
            modelBuilder.Entity<DeveloperAvailability>()
                .HasKey(da => new { da.DeveloperId, da.AvailabilityId });
            modelBuilder.Entity<DeveloperWorkingTime>()
                .HasKey(dw => new { dw.DeveloperId, dw.WorkingTimeId});
            modelBuilder.Entity<DeveloperKnowledge>()
                .HasIndex(dk => new { dk.DeveloperId, dk.KnowledgeId })
                .IsUnique();
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
