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
        Task<IQueryable<Project>> GetWithAggreggationByAllAsync();
        Task<Project> GetWithAggreggationByIdAsync(Guid id);
    }
}
