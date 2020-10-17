using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace GFut.Application.Services
{
    public class PlayerRegistrationAppService : IPlayerRegistrationAppService
    {
        private readonly IPlayerRegistrationRepository _playerRegistrationRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public PlayerRegistrationAppService(IMapper mapper, IPlayerRegistrationRepository playerRegistrationRepository, IHostingEnvironment env)
        {
            _playerRegistrationRepository = playerRegistrationRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<PlayerRegistrationViewModel> GetAll()
        {
            return _playerRegistrationRepository.GetAll().ProjectTo<PlayerRegistrationViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<PlayerRegistrationViewModel> GetPlayerRegistrationByChampionshipId(int id)
        {
            return _playerRegistrationRepository.GetAll().Where(p => p.Subscription.ChampionshipId == id).ProjectTo<PlayerRegistrationViewModel>(_mapper.ConfigurationProvider);
        }

        public PlayerRegistrationViewModel GetById(int id)
        {
            return _mapper.Map<PlayerRegistrationViewModel>(_playerRegistrationRepository.GetById(id));
        }

        public void Update(PlayerRegistrationViewModel playerRegistrationViewModel)
        {
            _playerRegistrationRepository.Update(_mapper.Map<PlayerRegistration>(playerRegistrationViewModel));
        }

        public void Remove(int id)
        {
            _playerRegistrationRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(PlayerRegistrationViewModel playerRegistrationViewModel)
        {
            _playerRegistrationRepository.Add(_mapper.Map<PlayerRegistration>(playerRegistrationViewModel));
        }
    }
}
