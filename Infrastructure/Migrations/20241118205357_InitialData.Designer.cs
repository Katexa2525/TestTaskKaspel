﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20241118205357_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Jenre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Author = "Gaiman Neil",
                            ISBN = "978-1-4722-3435-3",
                            Jenre = "Fentasy",
                            Name = "Neil Gaiman: Neverwhere. The Illustrated Edition",
                            Year = 2017
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Author = "Хокинс Джефф",
                            ISBN = "978-5-907473-58-4",
                            Jenre = "Science",
                            Name = "Джефф Хокинс: 1000 мозгов. Новая теория интеллекта.",
                            Year = 2015
                        });
                });

            modelBuilder.Entity("Domain.Models.OrdBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BookId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrdBooks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            BookId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            OrderId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            BookId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            OrderId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                        });
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Name = "1 Заказ",
                            Number = 2,
                            OrderDate = new DateTime(2024, 11, 18, 23, 53, 57, 584, DateTimeKind.Local).AddTicks(4677)
                        });
                });

            modelBuilder.Entity("Domain.Models.OrdBook", b =>
                {
                    b.HasOne("Domain.Models.Order", null)
                        .WithMany("OrdBooks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Navigation("OrdBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
