using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Trainer.DAL.EntityTypeConfigurations;
using Trainer.Domain.Models;
using Bogus;
using System;
using Trainer.Domain.Enums;

namespace Trainer.DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PvExampleConfiguration());
            modelBuilder.ApplyConfiguration(new WordConfiguration());
            modelBuilder.ApplyConfiguration(new WordTrackConfigurtion());
            modelBuilder.ApplyConfiguration(new WordExampleConfiguration());
            modelBuilder.ApplyConfiguration(new PhrasalVerbConfiguration());
            modelBuilder.ApplyConfiguration(new PvTrackConfiguration());
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().HasData(GetWords());
            modelBuilder.Entity<PhrasalVerb>().HasData(GetVerbs());
            modelBuilder.Entity<PvExample>().HasData(GetPvExample());
            modelBuilder.Entity<WordExample>().HasData(GetWordExample());
            modelBuilder.Entity<User>().HasData(GetUsers());
            modelBuilder.Entity<WordTrack>().HasData(GetWordTracks());
        }

        private static ICollection<WordTrack> GetWordTracks()
        {
            return new List<WordTrack>()
            {
                new WordTrack { Id = 1, AuthorId = 1, Name = "100 most important words", Level = KnowledgeLevel.Beginer, Description = "My first track", CreatedAt = DateTimeOffset.Now }
            };
        }

        private static ICollection<User> GetUsers()
        {
            return new List<User>()
            {
                new User { Id = 1, Email = "peter@server.com", Name = "Peter", FirebaseId = null, CreatedAt = DateTimeOffset.Now },
                new User { Id = 2, Email = "nick@server.com", Name = "Nick", FirebaseId = null, CreatedAt = DateTimeOffset.Now },
                new User { Id = 3, Email = "jane@server.com", Name = "Jane", FirebaseId = null, CreatedAt = DateTimeOffset.Now }
            };
        }

        private static ICollection<WordExample> GetWordExample()
        {
            return new List<WordExample>()
            {
                new WordExample { Id = 1, WordId = 1, Phrase = "My name is John", Translation = "Меня зовут Джон", CreatedAt = DateTimeOffset.Now },
                new WordExample { Id = 2, WordId = 1, Phrase = "Her name is Jane", Translation = "Ее зовут Джейн", CreatedAt = DateTimeOffset.Now },
                new WordExample { Id = 3, WordId = 1, Phrase = "What's your name?", Translation = "Как тебя зовут?", CreatedAt = DateTimeOffset.Now },
                new WordExample { Id = 4, WordId = 2, Phrase = "He has an old car", Translation = "У него есть старая машина", CreatedAt = DateTimeOffset.Now },
                new WordExample { Id = 5, WordId = 2, Phrase = "She was really old", Translation = "Она была очень старая", CreatedAt = DateTimeOffset.Now }
            };
        }

        private static ICollection<PvExample> GetPvExample()
        {
            return new List<PvExample>()
            {
                new PvExample { Id = 1, PhrasalVerbId = 1, Phrase = "Why did you bring it up?", Translation = "Почему ты заговорил об этом", CreatedAt = DateTimeOffset.Now },
                new PvExample { Id = 2, PhrasalVerbId = 1, Phrase = "Don't even try to bring it up!", Translation = "Даже не пытайся сказать это!", CreatedAt = DateTimeOffset.Now },
                new PvExample { Id = 3, PhrasalVerbId = 2, Phrase = "I had to call the meeting off", Translation = "Я должен был отменить встречу", CreatedAt = DateTimeOffset.Now },
                new PvExample { Id = 4, PhrasalVerbId = 2, Phrase = "We should to call off the festival", Translation = "Нам стоит отменить фестиваль", CreatedAt = DateTimeOffset.Now },
                new PvExample { Id = 5, PhrasalVerbId = 4, Phrase = "We were held up yesterday till five p.m.", Translation = "Нас задержали вчера до 5 вечера", CreatedAt = DateTimeOffset.Now },
                new PvExample { Id = 6, PhrasalVerbId = 4, Phrase = "My boss held me up today", Translation = "Мой босс задержал меня сегодня", CreatedAt = DateTimeOffset.Now }
            };
        }

        private static ICollection<Word> GetWords()
        {
            return new List<Word>()
            {
                new Word { Id = 1, Text = "name", Transcription = "naim", Translation = "имя", CreatedAt = DateTimeOffset.Now },
                new Word { Id = 2, Text = "old", Transcription = "old", Translation = "имя", CreatedAt = DateTimeOffset.Now },
                new Word { Id = 3, Text = "work", Transcription = "work", Translation = "работать", CreatedAt = DateTimeOffset.Now },
                new Word { Id = 4, Text = "hope", Transcription = "heup", Translation = "надежда", CreatedAt = DateTimeOffset.Now },
                new Word { Id = 5, Text = "convey", Transcription = "konvei", Translation = "передавать", CreatedAt = DateTimeOffset.Now },
                new Word { Id = 6, Text = "gather", Transcription = "gather", Translation = "собирать", CreatedAt = DateTimeOffset.Now }
            };
        }

        private static ICollection<PhrasalVerb> GetVerbs()
        {
            return new List<PhrasalVerb>()
            {
                new PhrasalVerb { Id = 1, Text = "bring up", Translation = "упоминать, заводить разговор об", CreatedAt = DateTimeOffset.Now },
                new PhrasalVerb { Id = 2, Text = "call off", Translation = "отменять, отменить", CreatedAt = DateTimeOffset.Now },
                new PhrasalVerb { Id = 3, Text = "work out", Translation = "придумать что-нибудь", CreatedAt = DateTimeOffset.Now },
                new PhrasalVerb { Id = 4, Text = "hold up", Translation = "задерживать", CreatedAt = DateTimeOffset.Now },
                new PhrasalVerb { Id = 5, Text = "take it out on", Translation = "вызвериться на", CreatedAt = DateTimeOffset.Now },
                new PhrasalVerb { Id = 6, Text = "stick up for", Translation = "встать на защиту", CreatedAt = DateTimeOffset.Now }
            };
        }
    }
}
