using Luby.ProjectAppointments.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Domain.Models
{
    public class Developer : BaseEntity
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public StatusDeveloper Status { get; set; }

    }
}
