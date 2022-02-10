using Trainer.Domain.Enums;

namespace Trainer.Admin.Domain.Entities
{
    public class PhrasalVerbTrackWrite
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }

        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
    }
}
