using AutoMapper;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using GFut.Domain.Interfaces;
using GFut.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFut.Application.Services
{
    public class HoraryExtraAppService : IHoraryExtraAppService
    {
        private readonly IHoraryExtraRepository _horaryExtraRepository;
        private readonly IMapper _mapper;

        public HoraryExtraAppService(IMapper mapper, IHoraryExtraRepository horaryExtraRepository)
        {
            _horaryExtraRepository = horaryExtraRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HoraryExtraViewModel>> GetAll()
        {
            var result = await _horaryExtraRepository.GetAll();
            return result.Select(_mapper.Map<HoraryExtraViewModel>);
        }

        public async Task<HoraryExtraViewModel> GetById(int id)
        {
            return _mapper.Map<HoraryExtraViewModel>(await _horaryExtraRepository.GetById(id));
        }

        public void Update(HoraryExtraViewModel fieldViewModel)
        {
            _horaryExtraRepository.Update(_mapper.Map<HoraryExtra>(fieldViewModel));
        }

        public void Remove(int id)
        {
            _horaryExtraRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(HoraryExtraViewModel fieldViewModel)
        {
            _horaryExtraRepository.Add(_mapper.Map<HoraryExtra>(fieldViewModel));
        }

        public async Task<IEnumerable<HoraryExtraViewModel>> GetHoraryExtraByFieldId(int FieldId)
        {
            return _mapper.Map<IEnumerable<HoraryExtraViewModel>>(await _horaryExtraRepository.GetHoraryExtraByFieldId(FieldId));
        }
    }
}
