using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer.Domain.Enums;
using Trainer.Domain.Models;

namespace Trainer.DAL.EntityTypeConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Author)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(4000)
                .IsRequired();

            builder.Property(p => p.Level)
                .HasDefaultValue(KnowledgeLevel.Beginer)
                .IsRequired();

            builder.Property(p => p.BlobId)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
