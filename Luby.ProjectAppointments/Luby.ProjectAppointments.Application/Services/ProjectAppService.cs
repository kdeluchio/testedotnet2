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
        private readonly IProjectValidation _projectValidation;

        public ProjectAppService(IMapper mapper,
                                 IProjectRepository projectRepository,
                                 IProjectValidation projectValidation)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _projectValidation = projectValidation;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAll()
        {
            var result = await _projectRepository.GetWithAggregationByAllAsync();
            return result.ProjectTo<ProjectViewModel>(_mapper.ConfigurationProvider);
        }

        public async Task<ProjectViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProjectViewModel>(await _projectRepository.GetWithAggregationByIdAsync(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                return false;

            _projectValidation.ValidationOnRemoving(project);

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

            _projectValidation.ValidationOnUpdating(project);

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

            _projectValidation.ValidationOnCreating(project);

            await _projectRepository.InsertAsync(project);
            await _projectRepository.SaveChangesAsync();

            var result = await GetById(project.Id);
            return result;
        }

    }
}
