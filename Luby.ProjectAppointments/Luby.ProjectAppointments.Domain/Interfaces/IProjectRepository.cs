using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Domain.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<IQueryable<Project>> GetWithAggregationByAllAsync();
        Task<Project> GetWithAggregationByIdAsync(Guid id);
        bool HasLink(Guid ProjectId, Guid DeveloperId);
        bool IsActive(Guid ProjectId);

    }
}
