using AutoMapper;
using AutoMapper.QueryableExtensions;
using Luby.ProjectAppointments.Application.Interfaces;
using Luby.ProjectAppointments.Application.ViewModel.Appointment;
using Luby.ProjectAppointments.Domain.Interfaces;
using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Application.Services
{
    public class AppointmentAppService : IAppointmentAppService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentAppService(IMapper mapper,
                                     IAppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<AppointmentViewModel>> GetAll()
        {
            var result = await _appointmentRepository.GetByAllAsync();
            return result.ProjectTo<AppointmentViewModel>(_mapper.ConfigurationProvider);
        }

        public async Task<IEnumerable<AppointmentViewModel>> GetByDeveloperId(Guid id)
        {
            var result = await _appointmentRepository.GetWithAggregationByDeveloperIdAsync(id);
            return result.ProjectTo<AppointmentViewModel>(_mapper.ConfigurationProvider);
        }

        public async Task<IEnumerable<AppointmentViewModel>> GetByProjectId(Guid id)
        {
            var result = await _appointmentRepository.GetWithAggregationByProjectIdAsync(id);
            return result.ProjectTo<AppointmentViewModel>(_mapper.ConfigurationProvider);
        }

        public async Task<AppointmentViewModel> GetById(Guid id)
        {
            return _mapper.Map<AppointmentViewModel>(await _appointmentRepository.GetWithAggregationByIdAsync(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
                return false;

            await _appointmentRepository.DeleteAsync(id);
            await _appointmentRepository.SaveChangesAsync();

            return true;
        }

        public async Task<AppointmentViewModel> Update(AppointmentViewModel appointmentViewModel)
        {
            var appointment = _mapper.Map<Appointment>(appointmentViewModel);
            await _appointmentRepository.UpdateAsync(appointment);
            await _appointmentRepository.SaveChangesAsync();

            var result = await GetById(appointment.Id);
            return result;
        }

        public async Task<AppointmentViewModel> Create(NewAppointmentViewModel newAppointmentViewModel)
        {
            var appointment = _mapper.Map<Appointment>(newAppointmentViewModel);

            await _appointmentRepository.InsertAsync(appointment);
            await _appointmentRepository.SaveChangesAsync();

            var result = await GetById(appointment.Id);
            return result;
        }

    }
}
