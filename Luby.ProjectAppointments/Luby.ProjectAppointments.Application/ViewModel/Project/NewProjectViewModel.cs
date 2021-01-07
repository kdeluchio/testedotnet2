using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Luby.ProjectAppointments.Application.ViewModel.Project
{
    public class NewProjectViewModel
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(150, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrição é um campo obrigatório")]
        public string Description { get; set; }

        public virtual List<NewLinkedDeveloperViewModel> LinkedDevelopers { get; set; }

    }
}
