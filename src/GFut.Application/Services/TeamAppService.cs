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
    public class TeamAppService : ITeamAppService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public TeamAppService(IMapper mapper, ITeamRepository teamRepository, IConfiguration configuration)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<TeamViewModel>> GetAll()
        {
            var result = await _teamRepository.GetAll();
            return result.Select(_mapper.Map<TeamViewModel>);
        }

        public async Task<IEnumerable<TeamViewModel>> GetTeamPerson(int id)
        {
            return _mapper.Map<IEnumerable<TeamViewModel>>(await _teamRepository.GetTeamPerson(id));
        }

        public async Task<TeamViewModel> GetById(int id)
        {
            return _mapper.Map<TeamViewModel>(await _teamRepository.GetById(id));
        }

        public void Update(TeamViewModel teamViewModel)
        {
            string[] symbol = teamViewModel.Symbol.Split('/');

            if (symbol[0] != "data:image")
            {
                teamViewModel.Symbol = symbol[symbol.Count() - 1];
            }
            else
            {
                teamViewModel.Symbol = Divers.Base64ToImage(teamViewModel.Symbol, "TEAM");
            }

            teamViewModel.Picture = "semimagem.png";

            _teamRepository.Update(_mapper.Map<Team>(teamViewModel));

            var result = _teamRepository.GetTeamPerson(teamViewModel.PersonId).Result;

            if (teamViewModel.Active)
            {
                foreach (var item in result.Where(p => p.Active == true && p.Id != teamViewModel.Id))
                {
                    item.Active = false;
                    _teamRepository.Update(item);
                }
            }
        }

        public void Status(int id)
        {
            Team team = _teamRepository.GetById(id).Result;

            team.Active = true;

            _teamRepository.Update(team);

            var result =  _teamRepository.GetTeamPerson(team.PersonId).Result;

            List<Team> list = result.Where(p => p.Id != team.Id).ToList();

            list.ForEach(m => m.Active = false);

            _teamRepository.UpdateRange(list);

        }

        public void Add(TeamViewModel teamViewModel)
        {
            List<Team> list = _teamRepository.GetTeamPerson(teamViewModel.PersonId).Result.ToList();

            list.ForEach(m => m.Active = false);
            _teamRepository.UpdateRange(list);

            var config = _configuration.GetValue<string>("Config:AtletaBase64");

            if (teamViewModel.Symbol == "")
            {
                teamViewModel.Symbol = Divers.Base64ToImage(config, "TEAM");
            }
            else
            {
                teamViewModel.Symbol = Divers.Base64ToImage(teamViewModel.Symbol, "TEAM");
            }

            teamViewModel.Picture = "semimagem.png";


            _teamRepository.Add(_mapper.Map<Team>(teamViewModel));
        }

        public void Remove(int id)
        {
            Team team = _teamRepository.GetById(id).Result;
            team.State = false;

            _teamRepository.Update(team);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
