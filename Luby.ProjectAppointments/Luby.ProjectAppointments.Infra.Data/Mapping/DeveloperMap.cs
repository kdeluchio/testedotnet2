using Luby.ProjectAppointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Infra.Data.Mapping
{
    public class DeveloperMap : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.HasKey(i => i.Id);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.CPF)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Status)
                .HasColumnType("int")
                .IsRequired();

        }
    }
}
