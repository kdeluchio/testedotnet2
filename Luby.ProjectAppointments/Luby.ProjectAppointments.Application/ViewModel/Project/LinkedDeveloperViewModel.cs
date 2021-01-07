using Luby.ProjectAppointments.Application.ViewModel.Developer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Luby.ProjectAppointments.Application.ViewModel.Project
{
    public class LinkedDeveloperViewModel
    {
        [Required(ErrorMessage = "Id é um campo obrigatório")]
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "O Desenvolvedor é um campo obrigatório")]
        public Guid DeveloperId { get; set; }
        public virtual DeveloperViewModel Developer { get; set; }
    }
}
