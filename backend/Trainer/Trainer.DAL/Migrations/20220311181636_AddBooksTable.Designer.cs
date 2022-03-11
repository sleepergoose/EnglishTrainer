﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trainer.DAL.Context;

namespace Trainer.DAL.Migrations
{
    [DbContext(typeof(TrainerContext))]
    [Migration("20220311181636_AddBooksTable")]
    partial class AddBooksTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trainer.Domain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("BlobId")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int>("Level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Trainer.Domain.Models.PhrasalVerb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("PhrasalVerbs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(210), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "bring up",
                            Translation = "упоминать, заводить разговор об"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(262), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "call off",
                            Translation = "отменять, отменить"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(267), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "work out",
                            Translation = "придумать что-нибудь"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(270), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "hold up",
                            Translation = "задерживать"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(272), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "take it out on",
                            Translation = "вызвериться на"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(278), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "stick up for",
                            Translation = "встать на защиту"
                        });
                });

            modelBuilder.Entity("Trainer.Domain.Models.PvExample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PhrasalVerbId")
                        .HasColumnType("int");

                    b.Property<string>("Phrase")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("Id");

                    b.HasIndex("PhrasalVerbId");

                    b.ToTable("PvExamples");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(7658), new TimeSpan(0, 2, 0, 0, 0)),
                            PhrasalVerbId = 1,
                            Phrase = "Why did you bring it up?",
                            Translation = "Почему ты заговорил об этом"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(7707), new TimeSpan(0, 2, 0, 0, 0)),
                            PhrasalVerbId = 1,
                            Phrase = "Don't even try to bring it up!",
                            Translation = "Даже не пытайся сказать это!"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(7711), new TimeSpan(0, 2, 0, 0, 0)),
                            PhrasalVerbId = 2,
                            Phrase = "I had to call the meeting off",
                            Translation = "Я должен был отменить встречу"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(7714), new TimeSpan(0, 2, 0, 0, 0)),
                            PhrasalVerbId = 2,
                            Phrase = "We should to call off the festival",
                            Translation = "Нам стоит отменить фестиваль"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(7717), new TimeSpan(0, 2, 0, 0, 0)),
                            PhrasalVerbId = 4,
                            Phrase = "We were held up yesterday till five p.m.",
                            Translation = "Нас задержали вчера до 5 вечера"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 510, DateTimeKind.Unspecified).AddTicks(7723), new TimeSpan(0, 2, 0, 0, 0)),
                            PhrasalVerbId = 4,
                            Phrase = "My boss held me up today",
                            Translation = "Мой босс задержал меня сегодня"
                        });
                });

            modelBuilder.Entity("Trainer.Domain.Models.PvToTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PhrasalVerbId")
                        .HasColumnType("int");

                    b.Property<int>("PvTrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhrasalVerbId");

                    b.HasIndex("PvTrackId");

                    b.ToTable("PvToTracks");
                });

            modelBuilder.Entity("Trainer.Domain.Models.PvTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("PvTracks");
                });

            modelBuilder.Entity("Trainer.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirebaseId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 511, DateTimeKind.Unspecified).AddTicks(8713), new TimeSpan(0, 2, 0, 0, 0)),
                            Email = "peter@server.com",
                            Name = "Peter",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 511, DateTimeKind.Unspecified).AddTicks(8756), new TimeSpan(0, 2, 0, 0, 0)),
                            Email = "nick@server.com",
                            Name = "Nick",
                            Role = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 511, DateTimeKind.Unspecified).AddTicks(8760), new TimeSpan(0, 2, 0, 0, 0)),
                            Email = "jane@server.com",
                            Name = "Jane",
                            Role = 0
                        });
                });

            modelBuilder.Entity("Trainer.Domain.Models.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Transcription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 504, DateTimeKind.Unspecified).AddTicks(8898), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "name",
                            Transcription = "naim",
                            Translation = "имя"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 508, DateTimeKind.Unspecified).AddTicks(1608), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "old",
                            Transcription = "old",
                            Translation = "имя"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 508, DateTimeKind.Unspecified).AddTicks(1648), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "work",
                            Transcription = "work",
                            Translation = "работать"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 508, DateTimeKind.Unspecified).AddTicks(1653), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "hope",
                            Transcription = "heup",
                            Translation = "надежда"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 508, DateTimeKind.Unspecified).AddTicks(1656), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "convey",
                            Transcription = "konvei",
                            Translation = "передавать"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 508, DateTimeKind.Unspecified).AddTicks(1662), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "gather",
                            Transcription = "gather",
                            Translation = "собирать"
                        });
                });

            modelBuilder.Entity("Trainer.Domain.Models.WordExample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Phrase")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.ToTable("WordExamples");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 511, DateTimeKind.Unspecified).AddTicks(3037), new TimeSpan(0, 2, 0, 0, 0)),
                            Phrase = "My name is John",
                            Translation = "Меня зовут Джон",
                            WordId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 511, DateTimeKind.Unspecified).AddTicks(3083), new TimeSpan(0, 2, 0, 0, 0)),
                            Phrase = "Her name is Jane",
                            Translation = "Ее зовут Джейн",
                            WordId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 511, DateTimeKind.Unspecified).AddTicks(3086), new TimeSpan(0, 2, 0, 0, 0)),
                            Phrase = "What's your name?",
                            Translation = "Как тебя зовут?",
                            WordId = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 511, DateTimeKind.Unspecified).AddTicks(3089), new TimeSpan(0, 2, 0, 0, 0)),
                            Phrase = "He has an old car",
                            Translation = "У него есть старая машина",
                            WordId = 2
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 511, DateTimeKind.Unspecified).AddTicks(3091), new TimeSpan(0, 2, 0, 0, 0)),
                            Phrase = "She was really old",
                            Translation = "Она была очень старая",
                            WordId = 2
                        });
                });

            modelBuilder.Entity("Trainer.Domain.Models.WordToTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.Property<int>("WordTrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.HasIndex("WordTrackId");

                    b.ToTable("WordToTracks");
                });

            modelBuilder.Entity("Trainer.Domain.Models.WordTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("WordTracks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2022, 3, 11, 20, 16, 35, 512, DateTimeKind.Unspecified).AddTicks(3805), new TimeSpan(0, 2, 0, 0, 0)),
                            Description = "My first track",
                            Level = 0,
                            Name = "100 most important words"
                        });
                });

            modelBuilder.Entity("Trainer.Domain.Models.PvExample", b =>
                {
                    b.HasOne("Trainer.Domain.Models.PhrasalVerb", "PhrasalVerb")
                        .WithMany("Examples")
                        .HasForeignKey("PhrasalVerbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhrasalVerb");
                });

            modelBuilder.Entity("Trainer.Domain.Models.PvToTrack", b =>
                {
                    b.HasOne("Trainer.Domain.Models.PhrasalVerb", "PhrasalVerb")
                        .WithMany("Tracks")
                        .HasForeignKey("PhrasalVerbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trainer.Domain.Models.PvTrack", "PvTrack")
                        .WithMany("PhrasalVerbs")
                        .HasForeignKey("PvTrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhrasalVerb");

                    b.Navigation("PvTrack");
                });

            modelBuilder.Entity("Trainer.Domain.Models.PvTrack", b =>
                {
                    b.HasOne("Trainer.Domain.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Trainer.Domain.Models.WordExample", b =>
                {
                    b.HasOne("Trainer.Domain.Models.Word", "Word")
                        .WithMany("Examples")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Trainer.Domain.Models.WordToTrack", b =>
                {
                    b.HasOne("Trainer.Domain.Models.Word", "Word")
                        .WithMany("Tracks")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trainer.Domain.Models.WordTrack", "WordTrack")
                        .WithMany("Words")
                        .HasForeignKey("WordTrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");

                    b.Navigation("WordTrack");
                });

            modelBuilder.Entity("Trainer.Domain.Models.WordTrack", b =>
                {
                    b.HasOne("Trainer.Domain.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Trainer.Domain.Models.PhrasalVerb", b =>
                {
                    b.Navigation("Examples");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Trainer.Domain.Models.PvTrack", b =>
                {
                    b.Navigation("PhrasalVerbs");
                });

            modelBuilder.Entity("Trainer.Domain.Models.Word", b =>
                {
                    b.Navigation("Examples");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Trainer.Domain.Models.WordTrack", b =>
                {
                    b.Navigation("Words");
                });
#pragma warning restore 612, 618
        }
    }
}
