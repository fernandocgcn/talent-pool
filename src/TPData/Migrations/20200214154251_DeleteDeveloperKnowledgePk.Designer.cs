﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPData;

namespace TPData.Migrations
{
    [DbContext(typeof(TPDbContext))]
    [Migration("20200214154251_DeleteDeveloperKnowledgePk")]
    partial class DeleteDeveloperKnowledgePk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TPDomain.Models.Availability", b =>
                {
                    b.Property<int>("AvailabilityId")
                        .HasColumnName("ava_id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("ava_description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AvailabilityId");

                    b.ToTable("tb_availability","dbo");

                    b.HasData(
                        new
                        {
                            AvailabilityId = 1,
                            Description = "Up to 4 hours per day / Até 4 horas por dia"
                        },
                        new
                        {
                            AvailabilityId = 2,
                            Description = "4 to 6 hours per day / De 4 á 6 horas por dia"
                        },
                        new
                        {
                            AvailabilityId = 3,
                            Description = "6 to 8 hours per day /De 6 á 8 horas por dia"
                        },
                        new
                        {
                            AvailabilityId = 4,
                            Description = "Up to 8 hours a day (are you sure?) / Acima de 8 horas por dia (tem certeza?)"
                        },
                        new
                        {
                            AvailabilityId = 5,
                            Description = "Only weekends / Apenas finais de semana"
                        });
                });

            modelBuilder.Entity("TPDomain.Models.Developer", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("dev_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("dev_city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrudLink")
                        .HasColumnName("dev_crud_link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("dev_email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ExtraKnowledge")
                        .HasColumnName("dev_extra_knowledge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedIn")
                        .HasColumnName("dev_linkedin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("dev_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Portfolio")
                        .HasColumnName("dev_portfolio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnName("dev_salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Skype")
                        .IsRequired()
                        .HasColumnName("dev_skype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("dev_state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Whatsapp")
                        .IsRequired()
                        .HasColumnName("dev_whatsapp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeveloperId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("tb_developer","dbo");
                });

            modelBuilder.Entity("TPDomain.Models.DeveloperAvailability", b =>
                {
                    b.Property<int>("dev_id")
                        .HasColumnType("int");

                    b.Property<int>("ava_id")
                        .HasColumnType("int");

                    b.HasKey("dev_id", "ava_id");

                    b.HasIndex("ava_id");

                    b.ToTable("tb_developer_availability","dbo");
                });

            modelBuilder.Entity("TPDomain.Models.DeveloperKnowledge", b =>
                {
                    b.Property<int>("dev_id")
                        .HasColumnType("int");

                    b.Property<int>("kno_id")
                        .HasColumnType("int");

                    b.Property<short?>("Rate")
                        .IsRequired()
                        .HasColumnName("dek_rate")
                        .HasColumnType("smallint");

                    b.HasKey("dev_id", "kno_id");

                    b.HasIndex("kno_id");

                    b.ToTable("tb_developer_knowledge","dbo");
                });

            modelBuilder.Entity("TPDomain.Models.DeveloperWorkingTime", b =>
                {
                    b.Property<int>("dev_id")
                        .HasColumnType("int");

                    b.Property<int>("wot_id")
                        .HasColumnType("int");

                    b.HasKey("dev_id", "wot_id");

                    b.HasIndex("wot_id");

                    b.ToTable("tb_developer_working_time","dbo");
                });

            modelBuilder.Entity("TPDomain.Models.Knowledge", b =>
                {
                    b.Property<int>("KnowledgeId")
                        .HasColumnName("kno_id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("kno_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KnowledgeId");

                    b.ToTable("tb_knowledge","dbo");

                    b.HasData(
                        new
                        {
                            KnowledgeId = 1,
                            Name = "Ionic"
                        },
                        new
                        {
                            KnowledgeId = 2,
                            Name = "ReactJS"
                        },
                        new
                        {
                            KnowledgeId = 3,
                            Name = "React Native"
                        },
                        new
                        {
                            KnowledgeId = 4,
                            Name = "Android"
                        },
                        new
                        {
                            KnowledgeId = 5,
                            Name = "IOS"
                        },
                        new
                        {
                            KnowledgeId = 6,
                            Name = "HTML"
                        },
                        new
                        {
                            KnowledgeId = 7,
                            Name = "CSS"
                        },
                        new
                        {
                            KnowledgeId = 8,
                            Name = "Bootstrap"
                        },
                        new
                        {
                            KnowledgeId = 9,
                            Name = "Jquery"
                        },
                        new
                        {
                            KnowledgeId = 10,
                            Name = "AngularJs 1.*"
                        },
                        new
                        {
                            KnowledgeId = 11,
                            Name = "Angular"
                        },
                        new
                        {
                            KnowledgeId = 12,
                            Name = "Java"
                        },
                        new
                        {
                            KnowledgeId = 13,
                            Name = "Asp.Net MVC"
                        },
                        new
                        {
                            KnowledgeId = 14,
                            Name = "Asp.Net WebForm"
                        },
                        new
                        {
                            KnowledgeId = 15,
                            Name = "C"
                        },
                        new
                        {
                            KnowledgeId = 16,
                            Name = "C#"
                        },
                        new
                        {
                            KnowledgeId = 17,
                            Name = "NodeJS"
                        },
                        new
                        {
                            KnowledgeId = 18,
                            Name = "Cake"
                        },
                        new
                        {
                            KnowledgeId = 19,
                            Name = "Django"
                        },
                        new
                        {
                            KnowledgeId = 20,
                            Name = "Majento"
                        },
                        new
                        {
                            KnowledgeId = 21,
                            Name = "PHP"
                        },
                        new
                        {
                            KnowledgeId = 22,
                            Name = "Vue"
                        },
                        new
                        {
                            KnowledgeId = 23,
                            Name = "Wordpress"
                        },
                        new
                        {
                            KnowledgeId = 24,
                            Name = "Phyton"
                        },
                        new
                        {
                            KnowledgeId = 25,
                            Name = "Ruby"
                        },
                        new
                        {
                            KnowledgeId = 26,
                            Name = "My SQL Server"
                        },
                        new
                        {
                            KnowledgeId = 27,
                            Name = "My SQL"
                        },
                        new
                        {
                            KnowledgeId = 28,
                            Name = "Salesforce"
                        },
                        new
                        {
                            KnowledgeId = 29,
                            Name = "Photoshop"
                        },
                        new
                        {
                            KnowledgeId = 30,
                            Name = "Illustrator"
                        },
                        new
                        {
                            KnowledgeId = 31,
                            Name = "SEO"
                        },
                        new
                        {
                            KnowledgeId = 32,
                            Name = "Laravel"
                        });
                });

            modelBuilder.Entity("TPDomain.Models.WorkingTime", b =>
                {
                    b.Property<int>("WorkingTimeId")
                        .HasColumnName("wot_id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("wot_description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkingTimeId");

                    b.ToTable("tb_working_time","dbo");

                    b.HasData(
                        new
                        {
                            WorkingTimeId = 1,
                            Description = "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)"
                        },
                        new
                        {
                            WorkingTimeId = 2,
                            Description = "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)"
                        },
                        new
                        {
                            WorkingTimeId = 3,
                            Description = "Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)"
                        },
                        new
                        {
                            WorkingTimeId = 4,
                            Description = "Dawn (from 10 p.m. onwards) / Madrugada (de 22:00 em diante)"
                        },
                        new
                        {
                            WorkingTimeId = 5,
                            Description = "Business (from 08:00 a.m. to 06:00 p.m.) / Comercial (de 08:00 as 18:00)"
                        });
                });

            modelBuilder.Entity("TPDomain.Models.DeveloperAvailability", b =>
                {
                    b.HasOne("TPDomain.Models.Availability", "Availability")
                        .WithMany()
                        .HasForeignKey("ava_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TPDomain.Models.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("dev_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TPDomain.Models.DeveloperKnowledge", b =>
                {
                    b.HasOne("TPDomain.Models.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("dev_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPDomain.Models.Knowledge", "Knowledge")
                        .WithMany()
                        .HasForeignKey("kno_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TPDomain.Models.DeveloperWorkingTime", b =>
                {
                    b.HasOne("TPDomain.Models.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("dev_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPDomain.Models.WorkingTime", "WorkingTime")
                        .WithMany()
                        .HasForeignKey("wot_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
