using System.Collections.Generic;
using Trainer.Domain.Abstract;
using Trainer.Domain.Enums;

namespace Trainer.Domain.Models
{
    public sealed class User : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string FirebaseId { get; set; }
        public Role Role { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
