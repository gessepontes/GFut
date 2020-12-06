using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;
using System.Threading.Tasks;


namespace GFut.Application.Services
{
    public class PlayerRegistrationAppService : IPlayerRegistrationAppService
    {
        private readonly IPlayerRegistrationRepository _playerRegistrationRepository;
        private readonly IMapper _mapper;

        public PlayerRegistrationAppService(IMapper mapper, IPlayerRegistrationRepository playerRegistrationRepository)
        {
            _playerRegistrationRepository = playerRegistrationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerRegistrationViewModel>> GetAll()
        {
            var result = await _playerRegistrationRepository.GetAll();
            return result.Select(_mapper.Map<PlayerRegistrationViewModel>);
        }

        public async Task<IEnumerable<PlayerRegistrationViewModel>> GetPlayerRegistrationByChampionshipId(int id)
        {
            var result = await _playerRegistrationRepository.GetAll();
            return result.Where(p => p.Subscription.ChampionshipId == id).Select(_mapper.Map<PlayerRegistrationViewModel>);
        }

        public async Task<PlayerRegistrationViewModel> GetById(int id)
        {
            return _mapper.Map<PlayerRegistrationViewModel>(await _playerRegistrationRepository.GetById(id));
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
