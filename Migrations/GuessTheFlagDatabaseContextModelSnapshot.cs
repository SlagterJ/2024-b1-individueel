﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2024_b1_individueel.Data;

#nullable disable

namespace _2024_b1_individueel.Migrations
{
    [DbContext(typeof(GuessTheFlagDatabaseContext))]
    partial class GuessTheFlagDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_2024_b1_individueel.Models.Flag", b =>
                {
                    b.Property<int>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Identifier"));

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FlagDeckIdentifier")
                        .HasColumnType("int");

                    b.HasKey("Identifier");

                    b.HasIndex("CountryCode")
                        .IsUnique();

                    b.HasIndex("FlagDeckIdentifier");

                    b.ToTable("FlagSet");

                    b.HasData(
                        new
                        {
                            Identifier = 1,
                            CorrectAnswer = "Nederland",
                            CountryCode = "nl",
                            FlagDeckIdentifier = 1
                        },
                        new
                        {
                            Identifier = 2,
                            CorrectAnswer = "België",
                            CountryCode = "be",
                            FlagDeckIdentifier = 1
                        },
                        new
                        {
                            Identifier = 3,
                            CorrectAnswer = "Duitsland",
                            CountryCode = "de",
                            FlagDeckIdentifier = 1
                        },
                        new
                        {
                            Identifier = 4,
                            CorrectAnswer = "Canada",
                            CountryCode = "ca",
                            FlagDeckIdentifier = 2
                        },
                        new
                        {
                            Identifier = 5,
                            CorrectAnswer = "Verenigde Staten",
                            CountryCode = "us",
                            FlagDeckIdentifier = 2
                        });
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.FlagDeck", b =>
                {
                    b.Property<int>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Identifier"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Identifier");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FlagDeckSet");

                    b.HasData(
                        new
                        {
                            Identifier = 1,
                            Name = "Europa"
                        },
                        new
                        {
                            Identifier = 2,
                            Name = "Noord-Amerika"
                        });
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.Score", b =>
                {
                    b.Property<int>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Identifier"));

                    b.Property<string>("AchievedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AchievedScore")
                        .HasColumnType("int");

                    b.Property<int?>("FlagDeckIdentifier")
                        .HasColumnType("int");

                    b.HasKey("Identifier");

                    b.HasIndex("FlagDeckIdentifier");

                    b.ToTable("ScoreSet");

                    b.HasData(
                        new
                        {
                            Identifier = 1,
                            AchievedBy = "Jordy",
                            AchievedScore = 2,
                            FlagDeckIdentifier = 1
                        });
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.Flag", b =>
                {
                    b.HasOne("_2024_b1_individueel.Models.FlagDeck", "FlagDeck")
                        .WithMany("Flags")
                        .HasForeignKey("FlagDeckIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlagDeck");
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.Score", b =>
                {
                    b.HasOne("_2024_b1_individueel.Models.FlagDeck", "FlagDeck")
                        .WithMany("Scores")
                        .HasForeignKey("FlagDeckIdentifier");

                    b.Navigation("FlagDeck");
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.FlagDeck", b =>
                {
                    b.Navigation("Flags");

                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
