using System.Collections.Generic;
using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public sealed  class PhrasalVerb : BaseEntity
    {
        public string Text { get; set; }
        public string Translation { get; set; }
        public ICollection<PvToTrack> Tracks { get; set; }
        public ICollection<PvExample> Examples { get; set; }
    }
}
