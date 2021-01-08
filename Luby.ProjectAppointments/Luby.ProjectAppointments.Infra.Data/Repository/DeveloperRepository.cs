using Luby.ProjectAppointments.Domain.Interfaces;
using Luby.ProjectAppointments.Domain.Models;
using Luby.ProjectAppointments.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Infra.Data.Repository
{
    public class DeveloperRepository : BaseRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(DefaultContext context)
            : base(context)
        {
        }

        public async Task<IQueryable<Developer>> GetByEmailAsync(string eMail)
        {
            return DbSet.Where(x => x.Email.Trim() == eMail.Trim());
        }
    }
}
