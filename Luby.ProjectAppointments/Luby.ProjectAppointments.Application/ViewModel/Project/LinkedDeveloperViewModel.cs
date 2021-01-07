using Luby.ProjectAppointments.Application.ViewModel.Developer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Application.ViewModel.Project
{
    public class LinkedDeveloperViewModel
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid DeveloperId { get; set; }
        public virtual DeveloperViewModel Developer { get; set; }
    }
}
