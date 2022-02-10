using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OcelotApiGateway.Extensions;

namespace OcelotApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("https://localhost:5000");
                })
                .ConfigureAppConfiguration((hostBuilderContext, configBuilder) => configBuilder
                    .SetBasePath(hostBuilderContext.HostingEnvironment.ContentRootPath)
                    .AddOcelotConfiguration($"Configuration/Development") // {hostBuilderContext.HostingEnvironment.EnvironmentName}
                );
    }
}
