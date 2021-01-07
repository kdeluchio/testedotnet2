using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Luby.ProjectAppointments.Application.ViewModel.Appointment
{
    public class NewAppointmentViewModel
    {
        [Required(ErrorMessage = "Data Inicial é um campo obrigatório")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Data Final é um campo obrigatório")]
        public DateTime EndDate { get; set; }
       
        [Required(ErrorMessage = "O desenvolvedor é um campo obrigatório")]
        public Guid DeveloperId { get; set; }

        [Required(ErrorMessage = "O Projeto é um campo obrigatório")]
        public Guid ProjectId { get; set; }
    }
}
