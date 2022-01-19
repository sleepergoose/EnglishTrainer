using System.Collections.Generic;

namespace Trainer.Admin.Domain.Entities
{
    public sealed class PhrasalVerbRead
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Translation { get; set; }
        public ICollection<Example> Examples { get; set; }
    }
}
