using System;
using Trainer.Common.DTO.UserDTO;
using Trainer.Domain.Enums;
using Trainer.Domain.Models;

namespace Trainer.Common.DTO
{
    public sealed class WordTrackReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserReadShortDTO Author { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
