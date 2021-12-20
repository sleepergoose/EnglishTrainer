using Microsoft.EntityFrameworkCore;
using Trainer.Domain.Models;
using Trainer.DAL.Extensions;
using System.Threading.Tasks;
using System.Threading;
using Trainer.Domain.Abstract;
using System.Linq;
using System;

namespace Trainer.DAL.Context
{
    public class TrainerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Word> Words { get; set; }
        public DbSet<WordExample> WordExamples { get; set; }
        public DbSet<WordTrack> WordTracks { get; set; }
        public DbSet<WordToTrack> WordToTracks { get; set; }

        public DbSet<PhrasalVerb> PhrasalVerbs { get; set; }
        public DbSet<PvExample> PvExamples { get; set; }
        public DbSet<PvToTrack> PvToTracks { get; set; }
        public DbSet<PvTrack> PvTracks { get; set; }

        public TrainerContext(DbContextOptions<TrainerContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configure();
            modelBuilder.Ignore<Track>();
            modelBuilder.Seed();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditValues();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            SetAuditValues();
            return base.SaveChanges();
        }

        private void SetAuditValues()
        {
            var entries = ChangeTracker.Entries<BaseEntity>().ToList();

            if (!entries.Any(x => x.State == EntityState.Added))
                return;

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTimeOffset.Now;
                        break;
                }
            }
        }
    }
}
