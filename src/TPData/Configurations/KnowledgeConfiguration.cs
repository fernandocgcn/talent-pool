using TPDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPData.Configurations
{
    internal class KnowledgeConfiguration : IEntityTypeConfiguration<Knowledge>
    {
        public void Configure(EntityTypeBuilder<Knowledge> builder)
        {
            builder.ToTable("tb_knowledge");

            builder.Property(entity => entity.KnowledgeId)
                .HasColumnName("kno_id")
                .IsRequired();
            builder.Property(entity => entity.Name)
                .HasColumnName("kno_name")
                .IsRequired();

            builder.HasKey(entity => entity.KnowledgeId);
        }
    }
}
