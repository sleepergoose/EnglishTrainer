using System.Collections.Generic;
using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public sealed class WordTrack : Track 
    {
        public ICollection<WordToTrack> Words { get; set; }
    }
}
