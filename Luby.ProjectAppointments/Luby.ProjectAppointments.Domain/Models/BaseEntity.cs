using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Luby.ProjectAppointments.Domain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedIn { get; set; }

        public DateTime? UpdatedIn { get; set; }

    }
}
