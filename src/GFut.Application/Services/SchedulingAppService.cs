using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace GFut.Application.Services
{
    public class SchedulingAppService : ISchedulingAppService
    {
        private readonly ISchedulingRepository _schedulingRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public SchedulingAppService(IMapper mapper, ISchedulingRepository fieldRepository, IHostingEnvironment env)
        {
            _schedulingRepository = fieldRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<SchedulingViewModel> GetAll()
        {
            return _schedulingRepository.GetAll().ProjectTo<SchedulingViewModel>(_mapper.ConfigurationProvider);
        }

        public SchedulingViewModel GetById(int id)
        {
            return _mapper.Map<SchedulingViewModel>(_schedulingRepository.GetById(id));
        }

        public void Update(SchedulingViewModel fieldViewModel)
        {
            _schedulingRepository.Update(_mapper.Map<Scheduling>(fieldViewModel));
        }

        public void Remove(int id)
        {
            _schedulingRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(SchedulingViewModel fieldViewModel)
        {
            _schedulingRepository.Add(_mapper.Map<Scheduling>(fieldViewModel));
        }

        public IEnumerable<SchedulingViewModel> GetSearchScheduling(string search)
        {
            return _mapper.Map<IEnumerable<SchedulingViewModel>>(_schedulingRepository.GetAll().Where(p => p.Person.Name.Contains(search)));
        }

        public IEnumerable<SchedulingViewModel> GetSchedulingByFieldId(int FieldId)
        {
            return _mapper.Map<IEnumerable<SchedulingViewModel>>(_schedulingRepository.GetSchedulingByFieldId(FieldId));
        }
    }
}
