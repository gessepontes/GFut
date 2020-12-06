using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using Microsoft.Extensions.Configuration;
using GFut.Domain.Others;
using System.Linq;
using static GFut.Domain.Others.Enum;
using System.Threading.Tasks;

namespace GFut.Application.Services
{
    public class ChampionshipAppService : IChampionshipAppService
    {
        private readonly IChampionshipRepository _championshipRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ChampionshipAppService(IMapper mapper, IChampionshipRepository championshipRepository, IConfiguration configuration)
        {
            _championshipRepository = championshipRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<ChampionshipViewModel>> GetAll()
        {
            var result = await _championshipRepository.GetAll();
            return result.Select(_mapper.Map<ChampionshipViewModel>);
        }

        public async Task<IEnumerable<ChampionshipViewModel>> GetGroupChampionship()
        {
            var result = await _championshipRepository.GetAll();
            return result.Where(p => p.ChampionshipType == ChampionshipType.Grupos).Select(_mapper.Map<ChampionshipViewModel>);
        }

        public async Task<ChampionshipViewModel> GetById(int id)
        {
            return _mapper.Map<ChampionshipViewModel>(await _championshipRepository.GetById(id));
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
            var config = _configuration.GetValue<string>("Config:AtletaBase64");

            if (championshipViewModel.Picture == "")
            {
                championshipViewModel.Picture = Divers.Base64ToImage(config, "CHAMPIONSHIP");
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
