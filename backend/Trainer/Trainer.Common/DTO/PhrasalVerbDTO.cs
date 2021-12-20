using System;

namespace Trainer.Common.DTO
{
    public sealed class PhrasalVerbDTO
    {
        public string Text { get; set; }
        public string Translation { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
