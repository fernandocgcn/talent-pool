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

            builder.HasData(DATA);
        }

        private readonly Availability[] DATA =
        {
            new Availability
            {
                AvailabilityId = 1,
                Description = "Up to 4 hours per day / Até 4 horas por dia"
            },
            new Availability
            {
                AvailabilityId = 2,
                Description = "4 to 6 hours per day / De 4 á 6 horas por dia"
            },
            new Availability
            {
                AvailabilityId = 3,
                Description = "6 to 8 hours per day /De 6 á 8 horas por dia"
            },
            new Availability
            {
                AvailabilityId = 4,
                Description = "Up to 8 hours a day (are you sure?) / Acima de 8 horas por dia (tem certeza?)"
            },
            new Availability
            {
                AvailabilityId = 5,
                Description = "Only weekends / Apenas finais de semana"
            }
        };
    }
}
