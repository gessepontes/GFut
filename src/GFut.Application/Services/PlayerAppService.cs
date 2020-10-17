using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using GFut.Domain.Others;
using Microsoft.Extensions.Configuration;

namespace GFut.Application.Services
{
    public class PlayerAppService : IPlayerAppService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;


        public PlayerAppService(IMapper mapper, IPlayerRepository playerRepository, IHostingEnvironment env)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<PlayerViewModel> GetAll()
        {
            return _playerRepository.GetAll().ProjectTo<PlayerViewModel>(_mapper.ConfigurationProvider);
        }

        public PlayerViewModel GetById(int id)
        {
            return _mapper.Map<PlayerViewModel>(_playerRepository.GetById(id));
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

            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();


            if (playerViewModel.Picture == "")
            {
                playerViewModel.Picture = Divers.Base64ToImage(config.GetSection(key: "Config")["AtletaBase64"], "PLAYER");
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

        public IEnumerable<PlayerViewModel> GetPlayerTeam(int id)
        {
            return _mapper.Map<IEnumerable<PlayerViewModel>>(_playerRepository.GetPlayerTeam(id));
        }

        public IEnumerable<PlayerViewModel> GetPlayerTeamByIdSubscription(int id)
        {
            return _mapper.Map<IEnumerable<PlayerViewModel>>(_playerRepository.GetPlayerTeamByIdSubscription(id));
        }
    }
}
