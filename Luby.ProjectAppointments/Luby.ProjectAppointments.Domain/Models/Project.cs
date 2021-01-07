using Luby.ProjectAppointments.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Domain.Models
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusProject Status { get; set; }
        public virtual List<LinkedDeveloper> LinkedDevelopers { get; set; }

        public Project()
        {
            LinkedDevelopers = new List<LinkedDeveloper>();
        }

        public void AddDeveloper(LinkedDeveloper developer)
        {
            LinkedDevelopers.Add(developer);
        }
    }
}
