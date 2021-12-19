using Trainer.Domain.Abstract;

namespace Trainer.Domain.Models
{
    public sealed class PvToTrack : BaseEntity
    {
        public int PhrasalVerbId { get; set; }
        public int PvTrackId { get; set; }

        public PhrasalVerb PhrasalVerb { get; set; }
        public PvTrack PvTrack { get; set; }
    }
}
