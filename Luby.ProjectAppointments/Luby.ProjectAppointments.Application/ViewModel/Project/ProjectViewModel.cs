using Luby.ProjectAppointments.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Luby.ProjectAppointments.Application.ViewModel.Project
{
    public class ProjectViewModel
    {
        [Required(ErrorMessage = "Id é um campo obrigatório")]
        public Guid Id { get; set; }

        public DateTime CreatedIn { get; set; }

        public DateTime? UpdatedIn { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(150, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrição é um campo obrigatório")]
        public string Description { get; set; }

        public StatusProject Status { get; set; }

        public virtual List<LinkedDeveloperViewModel> LinkedDevelopers { get; set; }
    }
}
