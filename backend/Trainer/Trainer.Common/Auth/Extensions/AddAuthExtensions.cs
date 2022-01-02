using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Trainer.Common.Auth.Constants;
using Trainer.Domain.Enums;
using Trainer.Common.Auth.Models;
using Trainer.Common.Auth.Handlers;

namespace Trainer.BL.Extensions
{
    public static class AddAuthExtensions
    {
        public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            string firebaseProjectId = configuration["GOOGLE_CREDENTIALS:project_id"];

            services.AddSingleton<IAuthorizationHandler, RoleRequirementHandler>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = true;
                    opt.Authority = $"https://securetoken.google.com/{firebaseProjectId}";

                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = $"https://securetoken.google.com/{firebaseProjectId}", 
                        ValidateAudience = true,
                        ValidAudience = firebaseProjectId,
                        ValidateLifetime = true
                    };

                    opt.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = AuthOnMessageReceived,
                    };
                });

            services.AddAuthorization(opt =>
            {
                opt.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireClaim(Claims.Id)
                    .RequireClaim(ClaimTypes.Role)
                    .Build();

                opt.AddPolicy(Policies.IsAdmin,
                    policy => policy.AddRequirements(
                        new RoleRequirement(Role.Admin)));

                opt.AddPolicy(Policies.IsUser,
                    policy => policy.AddRequirements(
                        new RoleRequirement(new List<Role> {
                            Role.Admin,
                            Role.User
                        })));
            });
        }

        private static async Task AuthOnMessageReceived(MessageReceivedContext context)
        {
            var accessToken = context.Request.Query["access_token"];

            if (!string.IsNullOrEmpty(accessToken))
            {
                context.Token = accessToken;
            }

            await Task.CompletedTask;
        }
    }
}
