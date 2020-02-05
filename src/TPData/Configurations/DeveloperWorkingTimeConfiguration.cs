using TPDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPData.Configurations
{
    internal class DeveloperWorkingTimeConfiguration : IEntityTypeConfiguration<DeveloperWorkingTime>
    {
        public void Configure(EntityTypeBuilder<DeveloperWorkingTime> builder)
        {
            builder.ToTable("tb_developer_working_time");

            builder.Property<int>("dev_id").IsRequired();
            builder.Property<int>("wot_id").IsRequired();

            builder.HasKey(new string[] { "dev_id", "wot_id" });

            builder.HasOne(entity => entity.Developer)
                .WithMany()
                .HasForeignKey("dev_id")
                .IsRequired();
            builder.HasOne(entity => entity.WorkingTime)
                .WithMany()
                .HasForeignKey("wot_id")
                .IsRequired();
        }
    }
}
