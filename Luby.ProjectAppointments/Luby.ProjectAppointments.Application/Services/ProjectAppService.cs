using AutoMapper;
using AutoMapper.QueryableExtensions;
using Luby.ProjectAppointments.Application.Interfaces;
using Luby.ProjectAppointments.Application.ViewModel.Project;
using Luby.ProjectAppointments.Domain.Interfaces;
using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Application.Services
{
    public class ProjectAppService : IProjectAppService
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        public ProjectAppService(IMapper mapper,
                                 IProjectRepository projectRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAll()
        {
            var result = await _projectRepository.GetWithAggreggationByAllAsync();
            return result.ProjectTo<ProjectViewModel>(_mapper.ConfigurationProvider);
        }

        public async Task<ProjectViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProjectViewModel>(await _projectRepository.GetWithAggreggationByIdAsync(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            var developer = await _projectRepository.GetByIdAsync(id);
            if (developer == null)
                return false;

            await _projectRepository.DeleteAsync(id);
            await _projectRepository.SaveChangesAsync();

            return true;
        }

        public async Task<ProjectViewModel> Update(ProjectViewModel projectViewModel)
        {
            var project = _mapper.Map<Project>(projectViewModel);
            foreach (var item in project.LinkedDevelopers)
            {
                if (item.ProjectId == Guid.Empty)
                    continue;

                item.ProjectId = project.Id;
            }

            await _projectRepository.UpdateAsyncCollection(project, null, p => p.LinkedDevelopers);
            await _projectRepository.SaveChangesAsync();

            var result = await GetById(project.Id);
            return result;
        }

        public async Task<ProjectViewModel> Create(NewProjectViewModel newProjectViewModel)
        {
            var project = _mapper.Map<Project>(newProjectViewModel);
            foreach (var item in project.LinkedDevelopers)
            {
                if (item.ProjectId == Guid.Empty)
                    continue;

                item.ProjectId = project.Id;
            }

            await _projectRepository.InsertAsync(project);
            await _projectRepository.SaveChangesAsync();

            var result = await GetById(project.Id);
            return result;
        }

    }
}
