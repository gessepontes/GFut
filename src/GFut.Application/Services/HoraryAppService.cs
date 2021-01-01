using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using static GFut.Domain.Others.Enum;

namespace GFut.Application.Services
{
    public class HoraryAppService : IHoraryAppService
    {
        private readonly IHoraryRepository _horaryRepository;
        private readonly IHoraryExtraRepository _horaryExtraRepository;
        private readonly ISchedulingRepository _schedulingRepository;

        private readonly IMapper _mapper;

        public HoraryAppService(IMapper mapper,
            IHoraryRepository horaryRepository,
            IHoraryExtraRepository horaryExtraRepository,
            ISchedulingRepository schedulingRepository)
        {
            _horaryRepository = horaryRepository;
            _horaryExtraRepository = horaryExtraRepository;
            _schedulingRepository = schedulingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HoraryViewModel>> GetAll()
        {
            var result = await _horaryRepository.GetAll();
            return result.Select(_mapper.Map<HoraryViewModel>);
        }

        public async Task<HoraryViewModel> GetById(int id)
        {
            return _mapper.Map<HoraryViewModel>(await _horaryRepository.GetById(id));
        }

        public void Update(HoraryViewModel fieldViewModel)
        {
            _horaryRepository.Update(_mapper.Map<Horary>(fieldViewModel));
        }

        public void Remove(int id)
        {
            _horaryRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(HoraryViewModel fieldViewModel)
        {
            _horaryRepository.Add(_mapper.Map<Horary>(fieldViewModel));
        }

        public async Task<IEnumerable<HoraryViewModel>> GetHoraryByFieldId(int fieldId)
        {
            var result = await _horaryRepository.GetHoraryByFieldId(fieldId);
            return result.Select(_mapper.Map<HoraryViewModel>);
        }

        public async Task<IEnumerable<HoraryViewModel>> GetHoraryDrop(int type, int fieldItem, DateTime date, int horaryId)
        {
            List<HoraryViewModel> list = new List<HoraryViewModel>();
            var result = await _schedulingRepository.GetAll();


            if (type == 1)
            {
                int dayOfWeek = (int)date.DayOfWeek;

                var horary = await _horaryRepository.GetAll();

                foreach (var item in horary.Where(p => p.FieldItemId == fieldItem && p.DayWeek == dayOfWeek && p.State == true && p.Active == true))
                {
                    Scheduling scheduling = result.Where(p => p.Date == date && p.HoraryType == HoraryType.Default && p.HoraryId == item.Id).FirstOrDefault();

                    if (scheduling == null)
                    {
                        var newItem = new HoraryViewModel { Hour = item.Hour, Id = item.Id };
                        list.Add(newItem);
                    }
                    else
                    {
                        if (horaryId == scheduling.HoraryId)
                        {
                            var newItem = new HoraryViewModel { Hour = item.Hour, Id = item.Id };
                            list.Add(newItem);
                        }
                    }
                }
            }
            else
            {
                var horaryExtra = await _horaryExtraRepository.GetAll();

                foreach (var item in horaryExtra.Where(p => p.FieldItemId == fieldItem && p.Date == date))
                {
                    Scheduling scheduling = result.Where(p => p.Date == date && p.HoraryType == HoraryType.Extra && p.HoraryId == item.Id).FirstOrDefault();

                    if (scheduling == null)
                    {
                        var newItem = new HoraryViewModel { Hour = item.Hour, Id = item.Id };
                        list.Add(newItem);
                    }
                    else
                    {
                        if (horaryId == scheduling.HoraryId)
                        {
                            var newItem = new HoraryViewModel { Hour = item.Hour, Id = item.Id };
                            list.Add(newItem);
                        }
                    }
                }
            }

            return list.OrderBy(p => p.Hour).Select(_mapper.Map<HoraryViewModel>);
        }
    }
}
