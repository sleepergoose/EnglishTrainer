using System;

namespace Trainer.Common.DTO
{
    public sealed class WordDTO
    {
        public string Text { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
