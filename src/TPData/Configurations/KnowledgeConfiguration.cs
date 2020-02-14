using TPModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TPData.Configurations
{
    internal class KnowledgeConfiguration : IEntityTypeConfiguration<Knowledge>
    {
        public void Configure(EntityTypeBuilder<Knowledge> builder)
        {
            builder.ToTable("tb_knowledge", "dbo");

            builder.Property(entity => entity.KnowledgeId)
                .HasColumnName("kno_id")
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(entity => entity.Name)
                .HasColumnName("kno_name")
                .IsRequired();

            builder.HasKey(entity => entity.KnowledgeId);

            builder.HasData(DATA);
        }

        private readonly Knowledge[] DATA =
        {
            new Knowledge
            {
                KnowledgeId = 1,
                Name = "Ionic"
            },
            new Knowledge
            {
                KnowledgeId = 2,
                Name = "ReactJS"
            },
            new Knowledge
            {
                KnowledgeId = 3,
                Name = "React Native"
            },
            new Knowledge
            {
                KnowledgeId = 4,
                Name = "Android"
            },
            new Knowledge
            {
                KnowledgeId = 5,
                Name = "IOS"
            },
            new Knowledge
            {
                KnowledgeId = 6,
                Name = "HTML"
            },
            new Knowledge
            {
                KnowledgeId = 7,
                Name = "CSS"
            },
            new Knowledge
            {
                KnowledgeId = 8,
                Name = "Bootstrap"
            },
            new Knowledge
            {
                KnowledgeId = 9,
                Name = "Jquery"
            },
            new Knowledge
            {
                KnowledgeId = 10,
                Name = "AngularJs 1.*"
            },
            new Knowledge
            {
                KnowledgeId = 11,
                Name = "Angular"
            },
            new Knowledge
            {
                KnowledgeId = 12,
                Name = "Java"
            },
            new Knowledge
            {
                KnowledgeId = 13,
                Name = "Asp.Net MVC"
            },
            new Knowledge
            {
                KnowledgeId = 14,
                Name = "Asp.Net WebForm"
            },
            new Knowledge
            {
                KnowledgeId = 15,
                Name = "C"
            },
            new Knowledge
            {
                KnowledgeId = 16,
                Name = "C#"
            },
            new Knowledge
            {
                KnowledgeId = 17,
                Name = "NodeJS"
            },
            new Knowledge
            {
                KnowledgeId = 18,
                Name = "Cake"
            },
            new Knowledge
            {
                KnowledgeId = 19,
                Name = "Django"
            },
            new Knowledge
            {
                KnowledgeId = 20,
                Name = "Majento"
            },
            new Knowledge
            {
                KnowledgeId = 21,
                Name = "PHP"
            },
            new Knowledge
            {
                KnowledgeId = 22,
                Name = "Vue"
            },
            new Knowledge
            {
                KnowledgeId = 23,
                Name = "Wordpress"
            },
            new Knowledge
            {
                KnowledgeId = 24,
                Name = "Phyton"
            },
            new Knowledge
            {
                KnowledgeId = 25,
                Name = "Ruby"
            },
            new Knowledge
            {
                KnowledgeId = 26,
                Name = "My SQL Server"
            },
            new Knowledge
            {
                KnowledgeId = 27,
                Name = "My SQL"
            },
            new Knowledge
            {
                KnowledgeId = 28,
                Name = "Salesforce"
            },
            new Knowledge
            {
                KnowledgeId = 29,
                Name = "Photoshop"
            },
            new Knowledge
            {
                KnowledgeId = 30,
                Name = "Illustrator"
            },
            new Knowledge
            {
                KnowledgeId = 31,
                Name = "SEO"
            },
            new Knowledge
            {
                KnowledgeId = 32,
                Name = "Laravel"
            }
        };
    }
}
