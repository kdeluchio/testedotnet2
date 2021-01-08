using Luby.ProjectAppointments.Domain.Interfaces;
using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luby.ProjectAppointments.Domain.Validations
{
    public class ProjectValidation : IProjectValidation
    {
        private Project _project;
        private readonly IProjectRepository _projectRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public ProjectValidation(IProjectRepository projectRepository,
                                 IAppointmentRepository appointmentRepository)
        {
            _projectRepository = projectRepository;
            _appointmentRepository = appointmentRepository;
        }

        public void ValidationOnCreating(Project obj)
        {
            _project = obj;
            ValidateLinkedDevelopers();
        }

        public void ValidationOnRemoving(Project obj)
        {
            _project = obj;
            ValidateAppointments();
        }

        public void ValidationOnUpdating(Project obj)
        {
            _project = obj;
            ValidateLinkedDevelopers();
        }

        private void ValidateAppointments()
        {
           var result = _appointmentRepository.GetWithAggregationByProjectIdAsync(_project.Id).Result;
            if (result.ToList().Count() > 0)
            {
                throw new Exception("Este projeto já possui apontamentos, sendo assim não será possível excluí-lo.");
            }
        }

        private void ValidateLinkedDevelopers()
        {
            _project.LinkedDevelopers?.ForEach(x =>
            {
                if (_project.LinkedDevelopers.Count(y => y.DeveloperId == x.DeveloperId) > 1)
                {
                    throw new Exception(string.Format("O desenvolvedor {0}, já está vinculado no projeto.", x.Developer?.Name));
                }
            });
        }

    }
}
