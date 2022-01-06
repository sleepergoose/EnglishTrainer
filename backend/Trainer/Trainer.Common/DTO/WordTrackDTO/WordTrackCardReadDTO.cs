using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.Common.DTO.UserDTO;
using Trainer.Domain.Enums;

namespace Trainer.Common.DTO.WordTrackDTO
{
    public sealed class WordTrackCardReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserReadShortDTO Author { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int Amount { get; set; }
        public int Rate { get; set; } = 0;
    }
}
