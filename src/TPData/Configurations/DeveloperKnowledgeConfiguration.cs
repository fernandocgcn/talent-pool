using TPDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPData.Configurations
{
    internal class DeveloperKnowledgeConfiguration : IEntityTypeConfiguration<DeveloperKnowledge>
    {
        public void Configure(EntityTypeBuilder<DeveloperKnowledge> builder)
        {
            builder.ToTable("tb_developer_knowledge");

            builder.Property(entity => entity.DeveloperKnowledgeId)
                .HasColumnName("dek_id")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(entity => entity.Rate)
                .HasColumnName("dek_rate")
                .IsRequired();
            builder.Property<int>("dev_id").IsRequired();
            builder.Property<int>("kno_id").IsRequired();

            builder.HasKey(entity => entity.DeveloperKnowledgeId);
            builder.HasIndex(new string[] { "dev_id", "kno_id" })
                .IsUnique();

            builder.HasOne(entity => entity.Developer)
                .WithMany()
                .HasForeignKey("dev_id")
                .IsRequired();
            builder.HasOne(entity => entity.Knowledge)
                .WithMany()
                .HasForeignKey("kno_id")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
