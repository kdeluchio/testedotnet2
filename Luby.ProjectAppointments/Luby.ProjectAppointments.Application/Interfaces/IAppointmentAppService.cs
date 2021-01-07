using Luby.ProjectAppointments.Application.ViewModel.Appointment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Application.Interfaces
{
    public interface IAppointmentAppService
    {
        Task<IEnumerable<AppointmentViewModel>> GetAll();
        Task<IEnumerable<AppointmentViewModel>> GetByDeveloperId(Guid id);
        Task<IEnumerable<AppointmentViewModel>> GetByProjectId(Guid id);
        Task<AppointmentViewModel> GetById(Guid id);
        Task<AppointmentViewModel> Create(NewAppointmentViewModel newAppointmentViewModel);
        Task<AppointmentViewModel> Update(AppointmentViewModel appointmentViewModel);
        Task<bool> Remove(Guid id);
    }
}
