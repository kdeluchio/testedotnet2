using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Luby.ProjectAppointments.Infra.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        public DefaultContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DefaultContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString, optionsBuilder => optionsBuilder.ServerVersion(
                                                            new Version(5, 7, 19),
                                                            ServerType.MySql));

            return new DefaultContext(builder.Options);
        }
    }
}
