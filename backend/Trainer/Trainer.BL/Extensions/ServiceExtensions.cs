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
            services.AddScoped<WordTracksService>();
            services.AddScoped<PvTracksService>();
            services.AddSingleton<FirebaseService>();
            services.AddScoped<AuthService>();
            services.AddScoped<UsersService>();
            services.AddScoped<SearchService>();
            services.AddScoped<TrainerService>();
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
                cfg.AddProfile<TrainerProfile>();
            });
        }
    }
}
