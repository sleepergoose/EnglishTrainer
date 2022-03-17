using Trainer.Domain.Enums;

namespace Trainer.Admin.Domain.Entities
{
    public class BookWrite
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
        public string BlobId { get; set; }
    }
}
