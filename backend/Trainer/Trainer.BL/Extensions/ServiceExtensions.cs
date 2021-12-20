using Microsoft.Extensions.DependencyInjection;
using Trainer.BL.Services;
using Trainer.Common.MappingProfiles;

namespace Trainer.BL.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddScoped<WordsService>();
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<WordProfile>();
            });
        }
    }
}
