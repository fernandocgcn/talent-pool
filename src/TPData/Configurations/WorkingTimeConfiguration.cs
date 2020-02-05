using TPDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPData.Configurations
{
    internal class WorkingTimeConfiguration : IEntityTypeConfiguration<WorkingTime>
    {
        public void Configure(EntityTypeBuilder<WorkingTime> builder)
        {
            builder.ToTable("tb_working_time");

            builder.Property(entity => entity.WorkingTimeId)
                .HasColumnName("wot_id")
                .IsRequired();
            builder.Property(entity => entity.Description)
                .HasColumnName("wot_description")
                .IsRequired();

            builder.HasKey(entity => entity.WorkingTimeId);
        }
    }
}
