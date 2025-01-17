﻿using System;
using Trainer.Domain.Enums;
using Trainer.Domain.Models;

namespace Trainer.Common.DTO
{
    public sealed class PvTrackReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Author { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
