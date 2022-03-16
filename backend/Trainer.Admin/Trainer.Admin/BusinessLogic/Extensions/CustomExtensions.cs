using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.AzureBlobStorage;
using System.Data;
using System.Reflection;
using Trainer.Admin.BusinessLogic.Services;
using Trainer.Admin.Common.MappingProfiles;
using Trainer.Admin.DataAccess;
using Shared.RabbitMQ.Wrapper.Options;
using Shared.RabbitMQ.Wrapper.Extensions;
using Shared.RabbitMQ.Wrapper.Interfaces;
using Shared.RabbitMQ.Wrapper.Services;
using RabbitMQ.Client;
using System;
using Shared.RabbitMQ.Wrapper.Models;

namespace Trainer.Admin.BusinessLogic.Extensions
{
    public static class CustomExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<DbConnectionFactory>();

            services.AddScoped<IDbConnection>(provider => provider
                .GetRequiredService<DbConnectionFactory>()
                .GetConnection());

            services.AddScoped<WordsService>();
            services.AddScoped<PhrasalVerbsService>();
            services.AddScoped<PvTracksService>();
            services.AddScoped<BooksService>();
            services.AddScoped<BlobService>();

            services.AddOptions<BookProcessingRabbitMQOptions>().BindConfiguration(BookProcessingRabbitMQOptions.Key);
            services.AddRabbitMQService(configuration.GetSection("RabbitMQUri").Value);

            services.AddScoped<IMessageService, MessageService>();
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<WordProfile>();
                cfg.AddProfile<PhrasalVerbProfile>();
                cfg.AddProfile<ExampleProfile>();
                cfg.AddProfile<PvTrackProfile>();
            });
        }
    }
}
