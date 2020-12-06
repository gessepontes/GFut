using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;
using GFut.Domain.Others;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace GFut.Application.Services
{
    public class HoraryPriceAppService : IHoraryPriceAppService
    {
        private readonly IHoraryPriceRepository _horaryPriceRepository;
        private readonly IMapper _mapper;

        public HoraryPriceAppService(IMapper mapper, IHoraryPriceRepository fieldRepository)
        {
            _horaryPriceRepository = fieldRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HoraryPriceViewModel>> GetAll()
        {
            var result = await _horaryPriceRepository.GetAll();
            return result.Select(_mapper.Map<HoraryPriceViewModel>);
        }

        public async Task<HoraryPriceViewModel> GetById(int id)
        {
            return _mapper.Map<HoraryPriceViewModel>(await _horaryPriceRepository.GetById(id));
        }

        public void Update(HoraryPriceViewModel fieldViewModel)
        {
            _horaryPriceRepository.Update(_mapper.Map<HoraryPrice>(fieldViewModel));
        }

        public void Remove(int id)
        {
            _horaryPriceRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(HoraryPriceViewModel fieldViewModel)
        {
            _horaryPriceRepository.Add(_mapper.Map<HoraryPrice>(fieldViewModel));
        }

        public async Task<IEnumerable<HoraryPriceViewModel>> GetSearchHoraryPrice(string search)
        {
            var result = await _horaryPriceRepository.GetAll();
            return _mapper.Map<IEnumerable<HoraryPriceViewModel>>(result.Where(p => p.FieldItem.Name.Contains(search)));
        }

        public async Task<IEnumerable<HoraryPriceViewModel>> GetHoraryPriceByFieldId(int FieldId)
        {
            return _mapper.Map<IEnumerable<HoraryPriceViewModel>>(await _horaryPriceRepository.GetHoraryPriceByFieldId(FieldId));
        }
    }
}
