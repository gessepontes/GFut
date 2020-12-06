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
using System.Threading.Tasks;

namespace GFut.Application.Services
{
    public class SchedulingAppService : ISchedulingAppService
    {
        private readonly ISchedulingRepository _schedulingRepository;
        private readonly IMapper _mapper;

        public SchedulingAppService(IMapper mapper, ISchedulingRepository schedulingRepository)
        {
            _schedulingRepository = schedulingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SchedulingViewModel>> GetAll()
        {
            var result = await _schedulingRepository.GetAll();
            return result.Select(_mapper.Map<SchedulingViewModel>);
        }

        public async Task<SchedulingViewModel> GetById(int id)
        {
            return _mapper.Map<SchedulingViewModel>(await _schedulingRepository.GetById(id));
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
        public async Task<IEnumerable<SchedulingViewModel>> GetSchedulingByFieldId(int FieldId)
        {
            return _mapper.Map<IEnumerable<SchedulingViewModel>>(await _schedulingRepository.GetSchedulingByFieldId(FieldId));
        }
    }
}
