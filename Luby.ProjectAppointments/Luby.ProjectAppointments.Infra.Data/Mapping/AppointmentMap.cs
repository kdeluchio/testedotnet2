using Luby.ProjectAppointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Infra.Data.Mapping
{
    public class AppointmentMap : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.HasKey(i => i.Id);

            builder.Property(c => c.StartDate)
                    .HasColumnType("datetime")
                    .IsRequired(true);

            builder.Property(c => c.EndDate)
                    .HasColumnType("datetime")
                    .IsRequired(true);

            builder.HasOne(y => y.Project)
                    .WithMany()
                    .HasForeignKey("ProjectId")
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(y => y.Developer)
                    .WithMany()
                    .HasForeignKey("DeveloperId")
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    
    }
}
