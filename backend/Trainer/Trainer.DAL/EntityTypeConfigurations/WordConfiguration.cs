using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer.Domain.Models;

namespace Trainer.DAL.EntityTypeConfigurations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder
                .HasMany(w => w.Tracks)
                .WithOne(t => t.Word);

            builder
                .HasMany(w => w.Examples)
                .WithOne(e => e.Word);

            builder.Property(p => p.Text)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Transcription)
                .HasMaxLength(200);

            builder.Property(p => p.Translation)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
