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
    }
}
