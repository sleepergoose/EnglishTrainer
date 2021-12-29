using Trainer.Domain.Enums;

namespace Trainer.Common.DTO.UserDTO
{
    public sealed class UserWriteDTO
    {
        public string FirebaseId { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
