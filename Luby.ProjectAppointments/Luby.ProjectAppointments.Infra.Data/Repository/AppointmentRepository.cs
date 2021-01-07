using Luby.ProjectAppointments.Domain.Interfaces;
using Luby.ProjectAppointments.Domain.Models;
using Luby.ProjectAppointments.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Infra.Data.Repository
{

    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DefaultContext context)
            : base(context)
        {
        }

        public async Task<IQueryable<Appointment>> GetWithAggregationByAllAsync()
        {
            try
            {
                return DbSet.Include(x => x.Developer)
                            .Include(x => x.Project)
                            .ThenInclude(x => x.LinkedDevelopers)
                            .AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<Appointment>> GetWithAggregationByDeveloperIdAsync(Guid developerId)
        {
            try
            {
                return DbSet.Include(x => x.Developer)
                            .Include(x => x.Project)
                            .ThenInclude(x => x.LinkedDevelopers)
                            .Where(x => x.DeveloperId == developerId)
                            .AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IQueryable<Appointment>> GetWithAggregationByProjectIdAsync(Guid projectId)
        {
            try
            {
                return DbSet.Include(x => x.Developer)
                            .Include(x => x.Project)
                            .ThenInclude(x => x.LinkedDevelopers)
                            .Where(x => x.ProjectId == projectId)
                            .AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Appointment> GetWithAggregationByIdAsync(Guid id)
        {
            try
            {
                return await DbSet.Include(x => x.Developer)
                                  .Include(x => x.Project)
                                  .ThenInclude(x => x.LinkedDevelopers)
                                  .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
