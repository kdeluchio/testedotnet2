using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Domain.Interfaces
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        Task<IQueryable<Appointment>> GetWithAggregationByAllAsync();
        Task<Appointment> GetWithAggregationByIdAsync(Guid id);
        Task<IQueryable<Appointment>> GetWithAggregationByDeveloperIdAsync(Guid developerId);
        Task<IQueryable<Appointment>> GetWithAggregationByProjectIdAsync(Guid projectId);

    }
}
