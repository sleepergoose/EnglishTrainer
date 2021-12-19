using System.Collections.Generic;
using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public sealed class Word : BaseEntity
    {
        public string Text { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
        public ICollection<WordToTrack> Tracks { get; set; }
        public ICollection<WordExample> Examples { get; set; }
    }
}
