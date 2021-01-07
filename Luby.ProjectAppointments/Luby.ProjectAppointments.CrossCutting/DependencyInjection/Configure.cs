using Luby.ProjectAppointments.Application.Interfaces;
using Luby.ProjectAppointments.Application.Services;
using Luby.ProjectAppointments.Domain.Interfaces;
using Luby.ProjectAppointments.Infra.Data.Context;
using Luby.ProjectAppointments.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Luby.ProjectAppointments.CrossCutting.DependencyInjection
{
    public class ConfigureDependencyInjection
    {
        public static void DependenciesRepository(IServiceCollection serviceCollection)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection.AddDbContext<DefaultContext>(
                options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"))
            );

            serviceCollection.AddScoped<IDeveloperRepository, DeveloperRepository>();
            serviceCollection.AddScoped<IProjectRepository, ProjectRepository>();
            serviceCollection.AddScoped<IAppointmentRepository, AppointmentRepository>();

        }

        public static void DependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDeveloperAppService, DeveloperAppService>();
            serviceCollection.AddTransient<IProjectAppService, ProjectAppService>();

        }
    }
}
