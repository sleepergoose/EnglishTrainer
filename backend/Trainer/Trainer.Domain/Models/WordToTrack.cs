using System.Collections.Generic;
using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public sealed class WordToTrack : BaseEntity
    {
        public int WordId { get; set; }
        public int WordTrackId { get; set; }

        public Word Word { get; set; }
        public WordTrack WordTrack { get; set; }
    }
}
