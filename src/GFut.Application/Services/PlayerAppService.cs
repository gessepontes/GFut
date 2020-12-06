using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;
using GFut.Domain.Others;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace GFut.Application.Services
{
    public class PlayerAppService : IPlayerAppService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PlayerAppService(IMapper mapper, IPlayerRepository playerRepository, IConfiguration configuration)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<PlayerViewModel>> GetAll()
        {
            var result = await _playerRepository.GetAll();
            return result.Select(_mapper.Map<PlayerViewModel>);
        }

        public async Task<PlayerViewModel> GetById(int id)
        {
            return _mapper.Map<PlayerViewModel>(await _playerRepository.GetById(id));
        }

        public void Update(PlayerViewModel playerViewModel)
        {
            string[] picture = playerViewModel.Picture.Split('/');

            if (picture[0] != "data:image")
            {
                playerViewModel.Picture = picture[picture.Count() - 1];
            }
            else
            {
                playerViewModel.Picture = Divers.Base64ToImage(playerViewModel.Picture, "PLAYER");
            }

            _playerRepository.Update(_mapper.Map<Player>(playerViewModel));
        }

        public void Add(PlayerViewModel playerViewModel)
        {

            var config = _configuration.GetValue<string>("Config:AtletaBase64");

            if (playerViewModel.Picture == "")
            {
                playerViewModel.Picture = Divers.Base64ToImage(config, "PLAYER");
            }
            else
            {
                playerViewModel.Picture = Divers.Base64ToImage(playerViewModel.Picture, "PLAYER");
            }

            _playerRepository.Add(_mapper.Map<Player>(playerViewModel));
        }

        public void Remove(int id)
        {
            _playerRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<PlayerViewModel>> GetPlayerTeam(int id)
        {
            return _mapper.Map<IEnumerable<PlayerViewModel>>(await _playerRepository.GetPlayerTeam(id));
        }

        public async Task<IEnumerable<PlayerViewModel>> GetPlayerTeamByIdSubscription(int id)
        {
            return _mapper.Map<IEnumerable<PlayerViewModel>>(await _playerRepository.GetPlayerTeamByIdSubscription(id));
        }
    }
}
