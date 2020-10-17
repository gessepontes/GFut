using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using GFut.Domain.Others;
using System.Linq;
using static GFut.Domain.Others.Enum;

namespace GFut.Application.Services
{
    public class ChampionshipAppService : IChampionshipAppService
    {
        private readonly IChampionshipRepository _championshipRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;


        public ChampionshipAppService(IMapper mapper, IChampionshipRepository championshipRepository, IPersonRepository personRepository, IHostingEnvironment env)
        {
            _championshipRepository = championshipRepository;
            _personRepository = personRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<ChampionshipViewModel> GetAll()
        {
            return _championshipRepository.GetAll().ProjectTo<ChampionshipViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<ChampionshipViewModel> GetGroupChampionship()
        {
            return _championshipRepository.GetAll().Where(p => p.ChampionshipType == ChampionshipType.Grupos).ProjectTo<ChampionshipViewModel>(_mapper.ConfigurationProvider);
        }

        public ChampionshipViewModel GetById(int id)
        {
            return _mapper.Map<ChampionshipViewModel>(_championshipRepository.GetById(id));
        }

        public void Update(ChampionshipViewModel championshipViewModel)
        {
            string[] symbol = championshipViewModel.Picture.Split('/');

            if (symbol[0] != "data:image")
            {
                championshipViewModel.Picture = symbol[symbol.Count() - 1];
            }
            else
            {
                championshipViewModel.Picture = Divers.Base64ToImage(championshipViewModel.Picture, "CHAMPIONSHIP");
            }

            _championshipRepository.Update(_mapper.Map<Championship>(championshipViewModel));
        }

        public void Add(ChampionshipViewModel championshipViewModel)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();


            if (championshipViewModel.Picture == "")
            {
                championshipViewModel.Picture = Divers.Base64ToImage(config.GetSection(key: "Config")["AtletaBase64"], "CHAMPIONSHIP");
            }
            else
            {
                championshipViewModel.Picture = Divers.Base64ToImage(championshipViewModel.Picture, "CHAMPIONSHIP");
            }

            _championshipRepository.Add(_mapper.Map<Championship>(championshipViewModel));
        }

        public void Remove(int id)
        {
            _championshipRepository.Remove(id);

            //var removeCommand = new RemoveCustomerCommand(id);
            //Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
