using Luby.ProjectAppointments.Domain.Interfaces;
using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Domain.Validations
{
    public class AppointmentValidation : IAppointmentValidation
    {
        private Appointment _appointment;
        private readonly IProjectRepository _projectRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDeveloperRepository _developerRepository;

        public AppointmentValidation(IProjectRepository projectRepository,
                                     IAppointmentRepository appointmentRepository,
                                     IDeveloperRepository developerRepository)
        {
            _projectRepository = projectRepository;
            _appointmentRepository = appointmentRepository;
            _developerRepository = developerRepository;
        }

        public void ValidationOnCreating(Appointment obj)
        {
            _appointment = obj;

            ValidateProjectDeveloper();
            ValidateStatusProject();
            ValidateDataRange();
            ValidateDataRangeIntegrity();
            ValidateDeveloperId();
        }

        public void ValidationOnRemoving(Appointment obj)
        {
            _appointment = obj;
        }

        public void ValidationOnUpdating(Appointment obj)
        {
            _appointment = obj;

            ValidateProjectDeveloper();
            ValidateStatusProject();
            ValidateDataRange();
            ValidateDataRangeIntegrity();
            ValidateDeveloperId();
        }
        
        private void ValidateDataRange()
        {
            if (_appointment.EndDate < _appointment.StartDate)
            {
                throw new Exception("Data Final deve ser maior que data inicial.");
            }
        }

        private void ValidateDataRangeIntegrity()
        {
            var hasSameDate = _appointmentRepository.HasAppointmentsSameRange(_appointment.DeveloperId, _appointment.StartDate, _appointment.EndDate);
            if (hasSameDate)
            {
                throw new Exception("Para este intervalo de data o desenvolvedor já possui apontamentos.");
            }
        }

        private void ValidateProjectDeveloper()
        {
            var hasLink = _projectRepository.HasLink(_appointment.ProjectId, _appointment.DeveloperId);

            if (!hasLink)
            {
                throw new Exception("Este desenvolvedor não está vinculado com o projeto, sendo assim não é permitido apontar horas.");
            }
        }

        private void ValidateStatusProject()
        {
            var isActive = _projectRepository.IsActive(_appointment.ProjectId);

            if (!isActive)
            {
                throw new Exception("Não é permitido apontar horas em projetos inativos.");
            }
        }

        private void ValidateDeveloperId()
        {
            var dev = _developerRepository.GetByIdAsync(_appointment.DeveloperId).Result;
            if (dev == null || dev.Id == Guid.Empty)
            {
                throw new Exception("Este Desenvolvedor inválido.");
            }
        }

    }
}
