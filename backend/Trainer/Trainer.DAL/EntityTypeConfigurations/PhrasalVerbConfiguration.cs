using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer.Domain.Models;

namespace Trainer.DAL.EntityTypeConfigurations
{
    public class PhrasalVerbConfiguration : IEntityTypeConfiguration<PhrasalVerb>
    {
        public void Configure(EntityTypeBuilder<PhrasalVerb> builder)
        {
            builder
                .HasMany(pv => pv.Tracks)
                .WithOne(tr => tr.PhrasalVerb);

            builder
                .HasMany(pv => pv.Examples)
                .WithOne(tr => tr.PhrasalVerb);

            builder.Property(p => p.Text)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Translation)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
