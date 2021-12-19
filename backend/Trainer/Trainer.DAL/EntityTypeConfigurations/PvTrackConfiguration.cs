﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainer.Domain.Models;

namespace Trainer.DAL.EntityTypeConfigurations
{
    public class PvTrackConfiguration : IEntityTypeConfiguration<PvTrack>
    {
        public void Configure(EntityTypeBuilder<PvTrack> builder)
        {
            builder
                .HasMany(tr => tr.PhrasalVerbs);
        }
    }
}
