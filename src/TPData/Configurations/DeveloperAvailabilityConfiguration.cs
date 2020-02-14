using TPModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPData.Configurations
{
    internal class DeveloperAvailabilityConfiguration : IEntityTypeConfiguration<DeveloperAvailability>
    {
        public void Configure(EntityTypeBuilder<DeveloperAvailability> builder)
        {
            builder.ToTable("tb_developer_availability", "dbo");

            builder.Property<int>("dev_id").IsRequired();
            builder.Property<int>("ava_id").IsRequired();

            builder.HasKey(new string[] { "dev_id", "ava_id" });

            builder.HasOne(entity => entity.Developer)
                .WithMany()
                .HasForeignKey("dev_id")
                .IsRequired();
            builder.HasOne(entity => entity.Availability)
                .WithMany()
                .HasForeignKey("ava_id")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
