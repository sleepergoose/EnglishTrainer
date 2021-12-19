using System.Collections.Generic;
using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public sealed class PvTrack : Track
    {
        public ICollection<PvToTrack> PhrasalVerbs { get; set; }
    }
}
