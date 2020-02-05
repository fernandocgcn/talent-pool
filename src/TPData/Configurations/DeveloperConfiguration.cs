using TPDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPData.Configurations
{
    internal class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("tb_developer");

            builder.Property(entity => entity.DeveloperId)
                .HasColumnName("dev_id")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(entity => entity.Email)
                .HasColumnName("dev_email")
                .IsRequired();
            builder.Property(entity => entity.Name)
                .HasColumnName("dev_name")
                .IsRequired();
            builder.Property(entity => entity.City)
                .HasColumnName("dev_city")
                .IsRequired();
            builder.Property(entity => entity.State)
                .HasColumnName("dev_state")
                .IsRequired();
            builder.Property(entity => entity.Skype)
                .HasColumnName("dev_skype")
                .IsRequired();
            builder.Property(entity => entity.Whatsapp)
                .HasColumnName("dev_whatsapp")
                .IsRequired();
            builder.Property(entity => entity.Salary)
                .HasColumnName("dev_salary")
                .IsRequired();
            builder.Property(entity => entity.LinkedIn)
                .HasColumnName("dev_linkedin");
            builder.Property(entity => entity.Portfolio)
                .HasColumnName("dev_portfolio");
            builder.Property(entity => entity.ExtraKnowledge)
                .HasColumnName("dev_extra_knowledge");
            builder.Property(entity => entity.CrudLink)
                .HasColumnName("dev_crud_link");

            builder.HasKey(entity => entity.DeveloperId);
            builder.HasIndex(entity => entity.Email)
                .IsUnique();
        }
    }
}
