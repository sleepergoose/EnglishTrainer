using System.Collections.Generic;

namespace Trainer.Domain.Models
{
    public sealed class WordToTrack
    {
        public int WordId { get; set; }
        public int WordTrackId { get; set; }

        public Word Word { get; set; }
        public WordTrack WordTrack { get; set; }
    }
}
