using Luby.ProjectAppointments.Application.ViewModel.Developer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Application.Interfaces
{
    public interface IDeveloperAppService
    {
        Task<IEnumerable<DeveloperViewModel>> GetAll();
        Task<DeveloperViewModel> GetById(Guid id);
        Task<DeveloperViewModel> Create(NewDeveloperViewModel newDeveloperViewModel);
        Task<DeveloperViewModel> Update(DeveloperViewModel developerViewModel);
        Task<bool> Remove(Guid id);
    }
}
