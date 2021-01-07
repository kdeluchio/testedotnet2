﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Luby.ProjectAppointments.Application.Interfaces;
using Luby.ProjectAppointments.Application.ViewModel.Developer;
using Luby.ProjectAppointments.Domain.Interfaces;
using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Luby.ProjectAppointments.Application.Services
{
    public class DeveloperAppService : IDeveloperAppService
    {
        private readonly IMapper _mapper;
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperAppService(IMapper mapper,
                                   IDeveloperRepository developerRepository)
        {
            _mapper = mapper;
            _developerRepository = developerRepository;
        }

        public async Task<IEnumerable<DeveloperViewModel>> GetAll()
        {
            var result = await _developerRepository.GetByAllAsync();
            return result.ProjectTo<DeveloperViewModel>(_mapper.ConfigurationProvider);
        }

        public async Task<DeveloperViewModel> GetById(Guid id)
        {
            return _mapper.Map<DeveloperViewModel>(await _developerRepository.GetByIdAsync(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            var developer = await _developerRepository.GetByIdAsync(id);
            if (developer == null)
                return false;

            await _developerRepository.DeleteAsync(id);
            await _developerRepository.SaveChangesAsync();

            return true;
        }

        public async Task<DeveloperViewModel> Update(DeveloperViewModel developerViewModel)
        {
            var developer = _mapper.Map<Developer>(developerViewModel);
            await _developerRepository.UpdateAsync(developer);
            await _developerRepository.SaveChangesAsync();

            var result = await GetById(developer.Id);
            return result;
        }

        public async Task<DeveloperViewModel> Create(NewDeveloperViewModel newDeveloperViewModel)
        {
            var developer = _mapper.Map<Developer>(newDeveloperViewModel);

            await _developerRepository.InsertAsync(developer);
            await _developerRepository.SaveChangesAsync();

            var result = await GetById(developer.Id);
            return result;
        }

    }
}