using Luby.ProjectAppointments.Application.ViewModel.Project;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Application.Interfaces
{
    public interface IProjectAppService
    {
        Task<IEnumerable<ProjectViewModel>> GetAll();
        Task<ProjectViewModel> GetById(Guid id);
        Task<ProjectViewModel> Create(NewProjectViewModel newProjectViewModel);
        Task<ProjectViewModel> Update(ProjectViewModel projectViewModel);
        Task<bool> Remove(Guid id);
    }
}
