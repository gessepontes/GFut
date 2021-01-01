using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;
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
            var result = await _schedulingRepository.GetById(id);
            SchedulingViewModel data = _mapper.Map<SchedulingViewModel>(result);

            data.FieldItemId = data.HoraryType == Domain.Others.Enum.HoraryType.Default ? data.Horary.FieldItemId : data.HoraryExtra.FieldItemId;


            if (data.HoraryType != Domain.Others.Enum.HoraryType.Default)
            {
                data.HoraryId = data.HoraryExtraId;
                data.FieldItemId = data.HoraryExtra.FieldItemId;
            }
            else {
                data.FieldItemId = data.Horary.FieldItemId;
            }

            return data;
        }

        public void Update(SchedulingViewModel fieldViewModel)
        {
            if (fieldViewModel.HoraryType != Domain.Others.Enum.HoraryType.Default)
            {
                fieldViewModel.HoraryExtraId = fieldViewModel.HoraryId;
                fieldViewModel.HoraryId = null;
            }

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
            if (fieldViewModel.HoraryType != Domain.Others.Enum.HoraryType.Default)
            {
                fieldViewModel.HoraryExtraId = fieldViewModel.HoraryId;
                fieldViewModel.HoraryId = null;
            }

            _schedulingRepository.Add(_mapper.Map<Scheduling>(fieldViewModel));
        }
        public async Task<IEnumerable<SchedulingViewModel>> GetSchedulingByFieldId(int FieldId)
        {
            return _mapper.Map<IEnumerable<SchedulingViewModel>>(await _schedulingRepository.GetSchedulingByFieldId(FieldId));
        }
    }
}
