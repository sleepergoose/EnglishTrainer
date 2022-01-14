using System.Collections.Generic;

namespace Trainer.Studio.Domain.Entities
{
    public class WordWrite
    {
        public string Text { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
        public ICollection<Example> Examples { get; set; }
    }
}
