using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer.Domain.Enums;
using Trainer.Domain.Models;

namespace Trainer.DAL.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Tracks)
                .WithOne(tr => tr.Author);

            builder.Property(p => p.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.FirebaseId)
                .HasMaxLength(200);

            builder.Property(p => p.Role)
                .HasDefaultValue(Role.User);
        }
    }
}
