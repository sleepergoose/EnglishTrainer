using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Processor.Models;
using System;
using System.IO;
using Shared.RabbitMQ.Wrapper.Extensions;
using Processor.Interfaces;
using Shared.AzureBlobStorage;

namespace Processor.Services
{
    internal class ServiceContainer : IServiceProvider
    {
        private readonly IServiceProvider _provider;

        public ServiceContainer()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())   
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            services.AddOptions<BookProcessingRabbitMQOptions>().BindConfiguration(BookProcessingRabbitMQOptions.Key);
            
            services.AddRabbitMQService(configuration["RabbitMQUri"]);

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBlobService, BlobService>();

            _provider = services.BuildServiceProvider();
        }

        public object? GetService(Type serviceType)
        {
            return _provider.GetService(serviceType);
        }
    }
}
