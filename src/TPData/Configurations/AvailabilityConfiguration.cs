using TPDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPData.Configurations
{
    internal class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
    {
        public void Configure(EntityTypeBuilder<Availability> builder)
        {
            builder.ToTable("tb_availability");

            builder.Property(entity => entity.AvailabilityId)
                .HasColumnName("ava_id")
                .IsRequired();
            builder.Property(entity => entity.Description)
                .HasColumnName("ava_description")
                .IsRequired();

            builder.HasKey(entity => entity.AvailabilityId);
        }
    }
}
