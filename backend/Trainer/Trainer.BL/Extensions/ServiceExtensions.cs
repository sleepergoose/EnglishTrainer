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
            services.AddScoped<PhrasalVerbsService>();
            services.AddScoped<WordExamplesService>();
            services.AddScoped<PvExamplesService>();
            services.AddScoped<WordTracksService>();
            services.AddScoped<PvTracksService>();
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<WordProfile>();
                cfg.AddProfile<PhrasalVerbProfile>();
                cfg.AddProfile<WordExampleProfile>();
                cfg.AddProfile<PvExampleProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<WordTrackProfile>();
                cfg.AddProfile<PvTrackProfile>();
            });
        }
    }
}
