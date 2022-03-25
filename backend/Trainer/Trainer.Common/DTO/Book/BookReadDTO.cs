using Trainer.Domain.Enums;

namespace Trainer.Common.DTO.Book
{
    public class BookReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
        public string BlobId { get; set; }
    }
}
