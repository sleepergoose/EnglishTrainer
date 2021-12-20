using Trainer.Domain.Models;
using Trainer.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trainer.Domain.Abstract
{
    [NotMapped]
    public abstract class Track : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
    }
}
