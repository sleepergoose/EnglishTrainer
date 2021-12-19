using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public sealed class Track : BaseEntity
    {
        public string Word { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
    }
}
