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
    public class TeamAppService : ITeamAppService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamAppService(IMapper mapper, ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public IEnumerable<TeamViewModel> GetAll()
        {
            return _teamRepository.GetAll().ProjectTo<TeamViewModel>(_mapper.ConfigurationProvider);
        }

        public TeamViewModel GetById(int id)
        {
            return _mapper.Map<TeamViewModel>(_teamRepository.GetById(id));
        }

        public void Update(TeamViewModel teamViewModel)
        {
            _teamRepository.Update(_mapper.Map<Team>(teamViewModel));            
        }

        public void Add(TeamViewModel teamViewModel)
        {
            _teamRepository.Add(_mapper.Map<Team>(teamViewModel));
        }

        public void Remove(int id)
        {
            _teamRepository.Remove(id);            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
