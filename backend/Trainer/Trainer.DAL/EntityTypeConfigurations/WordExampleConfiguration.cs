using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer.Domain.Models;

namespace Trainer.DAL.EntityTypeConfigurations
{
    public class WordExampleConfiguration : IEntityTypeConfiguration<WordExample>
    {
        public void Configure(EntityTypeBuilder<WordExample> builder)
        {
            builder.Property(p => p.Phrase)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(p => p.Translation)
                .HasMaxLength(4000)
                .IsRequired();
        }
    }
}
