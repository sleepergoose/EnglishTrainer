using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Trainer.BL.Extensions;

namespace Trainer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var migrationAssembly = typeof(TrainerContext).Assembly.GetName().Name;

            services.AddDbContext<TrainerContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:TrainerDbConnection"],
                    opt => opt.MigrationsAssembly(migrationAssembly)));

            services.RegisterAutoMapper();
            services.RegisterCustomServices();

            services.AddMvc(options => options.EnableEndpointRouting = false);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMvcWithDefaultRoute();
        }
    }
}
