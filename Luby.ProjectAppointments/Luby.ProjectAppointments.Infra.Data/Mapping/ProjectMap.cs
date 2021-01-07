using Luby.ProjectAppointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Infra.Data.Mapping
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.HasKey(i => i.Id);

            builder.Property(c => c.Name)
                    .HasColumnType("varchar(150)")
                    .HasMaxLength(150)
                    .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(c => c.Status)
                .HasColumnType("int")
                .IsRequired();
        }

    }
}
