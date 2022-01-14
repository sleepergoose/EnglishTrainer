using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Reflection;
using Trainer.Studio.BusinessLogic.Services;
using Trainer.Studio.DataAccess;

namespace Trainer.Studio.BusinessLogic.Extensions
{
    public static class CustomExtensions
    {
        public static void AddCustomServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());

            service.AddScoped<DbConnectionFactory>();

            service.AddScoped<IDbConnection>(provider => provider
                .GetRequiredService<DbConnectionFactory>()
                .GetConnection());

            service.AddScoped<WordsService>();
        }
    }
}
