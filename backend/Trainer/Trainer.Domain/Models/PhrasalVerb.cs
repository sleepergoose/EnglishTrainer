using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public sealed  class PhrasalVerb : BaseEntity
    {
        public string Verb { get; set; }
        public string Translation { get; set; }
    }
}
