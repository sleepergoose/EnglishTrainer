using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer.Domain.Models;

namespace Trainer.DAL.EntityTypeConfigurations
{
    public class PvExampleConfiguration : IEntityTypeConfiguration<PvExample>
    {
        public void Configure(EntityTypeBuilder<PvExample> builder)
        {
            builder.Property(p => p.Phrase)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(p => p.Translation)
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(p => p.PhrasalVerbId)
                .IsRequired();
        }
    }
}
