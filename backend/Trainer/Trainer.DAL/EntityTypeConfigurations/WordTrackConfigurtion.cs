using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer.Domain.Models;

namespace Trainer.DAL.EntityTypeConfigurations
{
    public class WordTrackConfigurtion : IEntityTypeConfiguration<WordTrack>
    {
        public void Configure(EntityTypeBuilder<WordTrack> builder)
        {
            builder.ToTable("WordTracks");

            builder
                .HasMany(wt => wt.Words);

            builder.Property(p => p.AuthorId)
                .IsRequired();
        }
    }
}
