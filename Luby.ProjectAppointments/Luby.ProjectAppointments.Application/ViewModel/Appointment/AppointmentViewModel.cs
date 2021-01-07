using Luby.ProjectAppointments.Application.ViewModel.Developer;
using Luby.ProjectAppointments.Application.ViewModel.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Luby.ProjectAppointments.Application.ViewModel.Appointment
{
    public class AppointmentViewModel
    {
        [Required(ErrorMessage = "Id é um campo obrigatório")]
        public Guid Id { get; set; }

        public DateTime CreatedIn { get; set; }

        public DateTime? UpdatedIn { get; set; }

        [Required(ErrorMessage = "Data Inicial é um campo obrigatório")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Data Final é um campo obrigatório")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "O desenvolvedor é um campo obrigatório")]
        public Guid DeveloperId { get; set; }
        public virtual DeveloperViewModel Developer { get; set; }

        [Required(ErrorMessage = "O Projeto é um campo obrigatório")]
        public Guid ProjectId { get; set; }
        public virtual ProjectViewModel Project { get; set; }
    }
}
