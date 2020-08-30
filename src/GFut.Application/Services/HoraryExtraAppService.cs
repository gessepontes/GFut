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
    public class HoraryExtraAppService : IHoraryExtraAppService
    {
        private readonly IHoraryExtraRepository _horaryExtraRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public HoraryExtraAppService(IMapper mapper, IHoraryExtraRepository fieldRepository, IHostingEnvironment env)
        {
            _horaryExtraRepository = fieldRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<HoraryExtraViewModel> GetAll()
        {
            return _horaryExtraRepository.GetAll().ProjectTo<HoraryExtraViewModel>(_mapper.ConfigurationProvider);
        }

        public HoraryExtraViewModel GetById(int id)
        {
            return _mapper.Map<HoraryExtraViewModel>(_horaryExtraRepository.GetById(id));
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

        public IEnumerable<HoraryExtraViewModel> GetSearchHoraryExtra(string search)
        {
            return _mapper.Map<IEnumerable<HoraryExtraViewModel>>(_horaryExtraRepository.GetAll().Where(p => p.FieldItem.Name.Contains(search)));
        }
    }
}
