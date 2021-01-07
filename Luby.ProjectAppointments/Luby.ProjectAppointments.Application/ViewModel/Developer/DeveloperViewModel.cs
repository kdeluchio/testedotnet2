﻿using Luby.ProjectAppointments.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Luby.ProjectAppointments.Application.ViewModel.Developer
{
    public class DeveloperViewModel
    {
        [Required(ErrorMessage = "Id é um campo obrigatório")]
        public Guid Id { get; set; }

        public DateTime CreatedIn { get; set; }
        
        public DateTime? UpdatedIn { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(150, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CPF é um campo obrigatório")]
        [StringLength(11, ErrorMessage = "CPF deve ter no máximo {1} caracteres.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "E-mail é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(150, ErrorMessage = "E-mail deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        public StatusDeveloper Status { get; set; }
    }
}
