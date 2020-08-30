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
    public class HoraryAppService : IHoraryAppService
    {
        private readonly IHoraryRepository _horaryRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public HoraryAppService(IMapper mapper, IHoraryRepository fieldRepository, IHostingEnvironment env)
        {
            _horaryRepository = fieldRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<HoraryViewModel> GetAll()
        {
            return _horaryRepository.GetAll().ProjectTo<HoraryViewModel>(_mapper.ConfigurationProvider);
        }

        public HoraryViewModel GetById(int id)
        {
            return _mapper.Map<HoraryViewModel>(_horaryRepository.GetById(id));
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

        public IEnumerable<HoraryViewModel> GetSearchHorary(string search)
        {
            return _mapper.Map<IEnumerable<HoraryViewModel>>(_horaryRepository.GetAll().Where(p => p.FieldItem.Name.Contains(search)));
        }
    }
}
