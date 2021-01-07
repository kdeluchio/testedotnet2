using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Luby.ProjectAppointments.CrossCutting;
using Luby.ProjectAppointments.CrossCutting.DependencyInjection;
using AutoMapper;
using Luby.ProjectAppointments.CrossCutting.AutoMapper;
using Microsoft.OpenApi.Models;

namespace Luby.ProjectAppointments.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigureDependencyInjection.DependenciesRepository(services);
            ConfigureDependencyInjection.DependenciesService(services);
            services.AddAutoMapper(typeof(Mapping));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste Luby API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string swaggerUrl;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                swaggerUrl = "/swagger/v1/swagger.json";
            }
            else
            {
                app.UseDeveloperExceptionPage();
                swaggerUrl = "/api/swagger/v1/swagger.json";
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerUrl, "Teste Luby API");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options =>
            {
                options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
