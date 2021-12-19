using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public sealed class PvExample : EntityExample
    {
        public PhrasalVerb PhrasalVerb { get; set; }
    }
}
