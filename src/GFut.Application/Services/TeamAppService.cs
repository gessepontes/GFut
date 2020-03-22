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
    public class TeamAppService : ITeamAppService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;


        public TeamAppService(IMapper mapper, ITeamRepository teamRepository, IHostingEnvironment env)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<TeamViewModel> GetAll()
        {
            return _teamRepository.GetAll().ProjectTo<TeamViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<TeamViewModel> GetTeamPerson(int id)
        {
            return _mapper.Map<IEnumerable<TeamViewModel>>(_teamRepository.GetTeamPerson(id));
        }

        public IEnumerable<TeamViewModel> GetSearchTeamPerson(int id, string search)
        {
            return _mapper.Map<IEnumerable<TeamViewModel>>(_teamRepository.GetTeamPerson(id).Where(p => p.Name.Contains(search)));
        }

        public TeamViewModel GetById(int id)
        {
            return _mapper.Map<TeamViewModel>(_teamRepository.GetById(id));
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

            if (teamViewModel.Active)
            {
                foreach (var item in _teamRepository.GetTeamPerson(teamViewModel.PersonId).Where(p => p.Active == true && p.Id != teamViewModel.Id))
                {
                    item.Active = false;
                    _teamRepository.Update(item);
                }
            }
        }

        public void Status(int id)
        {
            Team team = _teamRepository.GetById(id);

            team.Active = true;

            _teamRepository.Update(team);

            foreach (var item in _teamRepository.GetTeamPerson(team.Id).Where(p => p.Active == true && p.Id != team.Id))
            {
                item.Active = false;
                _teamRepository.Update(item);
            }
        }

        public void Add(TeamViewModel teamViewModel)
        {
            foreach (var item in _teamRepository.GetTeamPerson(teamViewModel.PersonId).Where(p => p.Active == true))
            {
                item.Active = false;
                _teamRepository.Update(item);
            }

            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();


            if (teamViewModel.Symbol == "")
            {
                teamViewModel.Symbol = Divers.Base64ToImage(config.GetSection(key: "Config")["AtletaBase64"], "TEAM");
            }
            else
            {
                teamViewModel.Symbol = Divers.Base64ToImage(teamViewModel.Picture, "TEAM");
            }

            teamViewModel.Picture = "semimagem.png";


            _teamRepository.Add(_mapper.Map<Team>(teamViewModel));
        }

        public void Remove(int id)
        {
            Team team = _teamRepository.GetById(id);
            team.State = false;

            _teamRepository.Update(team);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
