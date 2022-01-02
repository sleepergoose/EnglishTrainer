using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Trainer.Common.Auth.Models;

namespace Trainer.Common.Auth.Handlers
{
    public sealed class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (requirement.Roles.Any(role => 
                context.User.HasClaim(ClaimTypes.Role, ((int)role).ToString())))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
