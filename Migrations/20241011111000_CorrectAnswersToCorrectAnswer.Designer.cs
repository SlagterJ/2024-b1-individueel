﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2024_b1_individueel.Data;

#nullable disable

namespace _2024_b1_individueel.Migrations
{
    [DbContext(typeof(GuessTheFlagDatabaseContext))]
    [Migration("20241011111000_CorrectAnswersToCorrectAnswer")]
    partial class CorrectAnswersToCorrectAnswer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_2024_b1_individueel.Models.Flag", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("FlagDeckIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Identifier");

                    b.HasIndex("CountryCode")
                        .IsUnique();

                    b.HasIndex("FlagDeckIdentifier");

                    b.ToTable("FlagSet");
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.FlagDeck", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Identifier");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FlagDeckSet");
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.Pupil", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TutorIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Identifier");

                    b.HasIndex("TutorIdentifier");

                    b.ToTable("PupilSet");
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.Score", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AchievedByIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AchievedScore")
                        .HasColumnType("int");

                    b.Property<Guid>("FlagDeckIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Identifier");

                    b.HasIndex("AchievedByIdentifier");

                    b.HasIndex("FlagDeckIdentifier");

                    b.ToTable("ScoreSet");
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.Tutor", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identifier");

                    b.ToTable("TutorSet");
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

            modelBuilder.Entity("_2024_b1_individueel.Models.Pupil", b =>
                {
                    b.HasOne("_2024_b1_individueel.Models.Tutor", "Tutor")
                        .WithMany("Pupils")
                        .HasForeignKey("TutorIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.Score", b =>
                {
                    b.HasOne("_2024_b1_individueel.Models.Pupil", "AchievedBy")
                        .WithMany("Scores")
                        .HasForeignKey("AchievedByIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_2024_b1_individueel.Models.FlagDeck", "FlagDeck")
                        .WithMany("Scores")
                        .HasForeignKey("FlagDeckIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AchievedBy");

                    b.Navigation("FlagDeck");
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.FlagDeck", b =>
                {
                    b.Navigation("Flags");

                    b.Navigation("Scores");
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.Pupil", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("_2024_b1_individueel.Models.Tutor", b =>
                {
                    b.Navigation("Pupils");
                });
#pragma warning restore 612, 618
        }
    }
}
