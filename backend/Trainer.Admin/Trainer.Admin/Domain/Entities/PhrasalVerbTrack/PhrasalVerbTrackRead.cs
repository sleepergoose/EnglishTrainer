using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.Domain.Enums;

namespace Trainer.Admin.Domain.Entities
{
    public class PhrasalVerbTrackRead
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }

        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
    }
}
