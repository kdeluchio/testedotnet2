using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Domain.Interfaces
{
    public interface IDeveloperRepository : IBaseRepository<Developer>
    {
        Task<IQueryable<Developer>> GetByEmailAsync(string eMail);
    }
}
