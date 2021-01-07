using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Domain.Models
{
    public class Appointment : BaseEntity
    {
        public  DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid DeveloperId { get; set; }
        public virtual Developer Developer { get; set; }
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

    }
}
