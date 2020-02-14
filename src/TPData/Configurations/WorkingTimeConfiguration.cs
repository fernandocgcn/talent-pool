using TPModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPData.Configurations
{
    internal class WorkingTimeConfiguration : IEntityTypeConfiguration<WorkingTime>
    {
        public void Configure(EntityTypeBuilder<WorkingTime> builder)
        {
            builder.ToTable("tb_working_time", "dbo");

            builder.Property(entity => entity.WorkingTimeId)
                .HasColumnName("wot_id")
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(entity => entity.Description)
                .HasColumnName("wot_description")
                .IsRequired();

            builder.HasKey(entity => entity.WorkingTimeId);

            builder.HasData(DATA);
        }

        private readonly WorkingTime[] DATA =
        {
            new WorkingTime
            {
                WorkingTimeId = 1,
                Description = "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)"
            },
            new WorkingTime
            {
                WorkingTimeId = 2,
                Description = "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)"
            },
            new WorkingTime
            {
                WorkingTimeId = 3,
                Description = "Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)"
            },
            new WorkingTime
            {
                WorkingTimeId = 4,
                Description = "Dawn (from 10 p.m. onwards) / Madrugada (de 22:00 em diante)"
            },
            new WorkingTime
            {
                WorkingTimeId = 5,
                Description = "Business (from 08:00 a.m. to 06:00 p.m.) / Comercial (de 08:00 as 18:00)"
            }
        };
    }
}
