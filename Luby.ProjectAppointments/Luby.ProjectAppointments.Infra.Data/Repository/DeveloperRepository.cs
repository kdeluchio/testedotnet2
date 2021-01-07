using Luby.ProjectAppointments.Domain.Interfaces;
using Luby.ProjectAppointments.Domain.Models;
using Luby.ProjectAppointments.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Infra.Data.Repository
{
    public class DeveloperRepository : BaseRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(DefaultContext context)
            : base(context)
        {
        }
    }
}
