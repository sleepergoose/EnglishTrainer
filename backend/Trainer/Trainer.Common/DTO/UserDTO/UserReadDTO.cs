using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.Domain.Enums;

namespace Trainer.Common.DTO.UserDTO
{
    public sealed class UserReadDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
