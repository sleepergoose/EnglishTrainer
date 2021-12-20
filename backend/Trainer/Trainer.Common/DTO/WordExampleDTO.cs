using System;

namespace Trainer.Common.DTO
{
    public sealed class WordExampleDTO
    {
        public string Phrase { get; set; }
        public string Translation { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
