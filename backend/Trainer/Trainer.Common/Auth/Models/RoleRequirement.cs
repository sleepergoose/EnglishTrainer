using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Trainer.Domain.Enums;

namespace Trainer.Common.Auth.Models
{
    internal sealed class RoleRequirement : IAuthorizationRequirement
    {
        public IList<Role> Roles { get; }

        public RoleRequirement(Role role)
        {
            Roles = new List<Role> { role };
        }

        public RoleRequirement(IList<Role> roles)
        {
            Roles = roles;
        }
    }
}
