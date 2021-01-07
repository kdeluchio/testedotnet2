using Luby.ProjectAppointments.Domain.Models;
using Luby.ProjectAppointments.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Infra.Data.Context
{
    public class DefaultContext : DbContext
    {
        public DbSet<Developer> Developer { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<LinkedDeveloper> LinkedDeveloper { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeveloperMap());
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new AppointmentMap());
            modelBuilder.ApplyConfiguration(new LinkedDeveloperMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
