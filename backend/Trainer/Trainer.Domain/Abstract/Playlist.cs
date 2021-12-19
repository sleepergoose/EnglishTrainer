using Trainer.Domain.Models;
using Trainer.Domain.Enums;

namespace Trainer.Domain.Abstract
{
    public abstract class Playlist : BaseEntity
    {
        public User Author { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
    }
}
