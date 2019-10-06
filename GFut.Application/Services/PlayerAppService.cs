using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;

namespace GFut.Application.Services
{
    public class PlayerAppService : IPlayerAppService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerAppService(IMapper mapper, IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public IEnumerable<PlayerViewModel> GetAll()
        {
            return _playerRepository.GetAll().ProjectTo<PlayerViewModel>(_mapper.ConfigurationProvider);
        }

        public PlayerViewModel GetById(int id)
        {
            return _mapper.Map<PlayerViewModel>(_playerRepository.GetById(id));
        }

        public void Update(PlayerViewModel personViewModel)
        {
            _playerRepository.Update(_mapper.Map<Player>(personViewModel));
        }

        public void Add(PlayerViewModel teamViewModel)
        {
            _playerRepository.Add(_mapper.Map<Player>(teamViewModel));
        }

        public void Remove(int id)
        {
            _playerRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
