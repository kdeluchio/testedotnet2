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
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DefaultContext context)
            : base(context)
        {
        }

        public async Task<IQueryable<Project>> GetWithAggregationByAllAsync()
        {
            try
            {
                return DbSet.Include(x => x.LinkedDevelopers)
                            .ThenInclude(x => x.Developer)
                            .AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Project> GetWithAggregationByIdAsync(Guid Id)
        {
            try
            {
                return await DbSet.Include(x => x.LinkedDevelopers)
                                  .ThenInclude(x => x.Developer)
                                  .SingleOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool HasLink(Guid ProjectId, Guid DeveloperId)
        {
            try
            {
                var result = DbSet.Include(x => x.LinkedDevelopers)
                                  .Where(x => x.Id == ProjectId
                                           && x.LinkedDevelopers.Where(y => y.DeveloperId == DeveloperId).Count() > 0)
                                  .Count();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsActive(Guid ProjectId)
        {
            try
            {
                var result = DbSet.Where(x => x.Id == ProjectId
                                           && x.Status == Domain.Enums.StatusProject.Active)
                                  .Count();

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
