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

namespace GFut.Application.Services
{
    public class HoraryPriceAppService : IHoraryPriceAppService
    {
        private readonly IHoraryPriceRepository _horaryPriceRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public HoraryPriceAppService(IMapper mapper, IHoraryPriceRepository fieldRepository, IHostingEnvironment env)
        {
            _horaryPriceRepository = fieldRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<HoraryPriceViewModel> GetAll()
        {
            return _horaryPriceRepository.GetAll().ProjectTo<HoraryPriceViewModel>(_mapper.ConfigurationProvider);
        }

        public HoraryPriceViewModel GetById(int id)
        {
            return _mapper.Map<HoraryPriceViewModel>(_horaryPriceRepository.GetById(id));
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

        public IEnumerable<HoraryPriceViewModel> GetSearchHoraryPrice(string search)
        {
            return _mapper.Map<IEnumerable<HoraryPriceViewModel>>(_horaryPriceRepository.GetAll().Where(p => p.FieldItem.Name.Contains(search)));
        }

        public IEnumerable<HoraryPriceViewModel> GetHoraryPriceByFieldId(int FieldId)
        {
            return _mapper.Map<IEnumerable<HoraryPriceViewModel>>(_horaryPriceRepository.GetHoraryPriceByFieldId(FieldId));
        }
    }
}
