using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public sealed class PvExample : EntityExample
    {
        public int PhrasalVerbId { get; set; }
        public PhrasalVerb PhrasalVerb { get; set; }
    }
}
