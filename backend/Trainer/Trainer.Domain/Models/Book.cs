using Trainer.Domain.Abstract;
using Trainer.Domain.Enums;

namespace Trainer.Domain.Models
{
    public sealed class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
        public string BlobId { get; set; }
    }
}
