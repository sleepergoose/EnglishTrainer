using Trainer.Domain.Enums;

namespace Trainer.Common.DTO
{
    public sealed class WordTrackWriteDTO
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
    }
}
