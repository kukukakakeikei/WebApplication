﻿// <auto-generated />
using System;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFramework.Migrations
{
    [DbContext(typeof(WebApplicationDbContext))]
    partial class WebApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entites.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Classes")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("DataCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Nickname")
                        .IsUnique();

                    b.HasIndex("PlayerId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e12b7286-157e-4c94-87aa-fbbd7eaf2a70"),
                            Classes = "Mage",
                            DataCreated = new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(3879),
                            Level = 99,
                            Nickname = "Code Man",
                            PlayerId = new Guid("dbff15ed-a31a-46f8-b82c-f49bef224ed5")
                        },
                        new
                        {
                            Id = new Guid("536fb9d8-ec40-4ec5-8e04-f70ebd1e8a1c"),
                            Classes = "Warrior",
                            DataCreated = new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(4114),
                            Level = 90,
                            Nickname = "Iron Man",
                            PlayerId = new Guid("dbff15ed-a31a-46f8-b82c-f49bef224ed5")
                        },
                        new
                        {
                            Id = new Guid("1f3b1016-223a-4ccc-b188-f2b5548fc1ac"),
                            Classes = "Druid",
                            DataCreated = new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(4118),
                            Level = 80,
                            Nickname = "Spider Man",
                            PlayerId = new Guid("dbff15ed-a31a-46f8-b82c-f49bef224ed5")
                        },
                        new
                        {
                            Id = new Guid("c12dd6e5-a143-49a4-ba09-cc9adfcddde0"),
                            Classes = "Death knight",
                            DataCreated = new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(4121),
                            Level = 90,
                            Nickname = "BatMan",
                            PlayerId = new Guid("8ef15996-cebe-4b3e-9594-7c541421c2b0")
                        },
                        new
                        {
                            Id = new Guid("dcb79c18-08df-4695-9487-686b08e931a3"),
                            Classes = "Paladin",
                            DataCreated = new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(4122),
                            Level = 99,
                            Nickname = "SuperMan",
                            PlayerId = new Guid("8ef15996-cebe-4b3e-9594-7c541421c2b0")
                        });
                });

            modelBuilder.Entity("Entites.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("DataCreated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Account")
                        .IsUnique();

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dbff15ed-a31a-46f8-b82c-f49bef224ed5"),
                            Account = "mw2021",
                            AccountType = "Free",
                            DataCreated = new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(2504)
                        },
                        new
                        {
                            Id = new Guid("8ef15996-cebe-4b3e-9594-7c541421c2b0"),
                            Account = "dc2021",
                            AccountType = "Free",
                            DataCreated = new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(2518)
                        });
                });

            modelBuilder.Entity("Entites.Character", b =>
                {
                    b.HasOne("Entites.Player", "Player")
                        .WithMany("Characters")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Entites.Player", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
