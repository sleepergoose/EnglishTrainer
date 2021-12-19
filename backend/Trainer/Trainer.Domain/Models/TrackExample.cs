using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public class TrackExample : BaseEntity
    {
        public string Phrase { get; set; }
        public string Translation { get; set; }
    }
}
