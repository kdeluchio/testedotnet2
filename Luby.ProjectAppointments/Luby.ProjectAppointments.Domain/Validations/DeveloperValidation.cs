using Luby.ProjectAppointments.Domain.Interfaces;
using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luby.ProjectAppointments.Domain.Validations
{
    public class DeveloperValidation : IDeveloperValidation
    {
        private Developer _developer;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public DeveloperValidation(IDeveloperRepository developerRepository,
                                   IAppointmentRepository appointmentRepository)
        {
            _developerRepository = developerRepository;
            _appointmentRepository = appointmentRepository;
        }

        public void ValidationOnCreating(Developer obj)
        {
            _developer = obj;
            ValidateDevelopersDuplicated();
        }

        public void ValidationOnRemoving(Developer obj)
        {
            _developer = obj;
            ValidateAppointments();
        }

        public void ValidationOnUpdating(Developer obj)
        {
            _developer = obj;
            ValidateDevelopersDuplicated();
        }

        private void ValidateDevelopersDuplicated()
        {
           var result = _developerRepository.GetByEmailAsync(_developer.Email).Result;
            if (result.Where(x => x.Id != _developer.Id).Count() > 0)
            {
                throw new Exception("Este e-mail já foi cadastrado, não é possível prosseguir com a operação.");
            }
        }

        private void ValidateAppointments()
        {
            var result =  _appointmentRepository.GetWithAggregationByDeveloperIdAsync(_developer.Id).Result;
            if (result.ToList().Count() > 0)
            {
                throw new Exception("Este desenvolvedor já possui apontamentos, sendo assim não será possível excluí-lo.");
            }
        }

    }
}
