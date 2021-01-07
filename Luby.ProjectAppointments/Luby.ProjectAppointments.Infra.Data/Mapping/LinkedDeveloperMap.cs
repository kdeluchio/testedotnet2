using Luby.ProjectAppointments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Infra.Data.Mapping
{
    public class LinkedDeveloperMap : IEntityTypeConfiguration<LinkedDeveloper>
    {
        public void Configure(EntityTypeBuilder<LinkedDeveloper> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.HasKey(i => i.Id);

            builder.HasOne(y => y.Project) 
           .WithMany(x => x.LinkedDevelopers)
           .HasForeignKey("ProjectId")
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(y => y.Developer)
                    .WithMany()
                    .HasForeignKey("DeveloperId")
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
