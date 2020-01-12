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
    public class ChampionshipAppService : IChampionshipAppService
    {
        private readonly IChampionshipRepository _championshipRepository;
        private readonly IMapper _mapper;

        public ChampionshipAppService(IMapper mapper, IChampionshipRepository championshipRepository)
        {
            _championshipRepository = championshipRepository;
            _mapper = mapper;
        }

        public IEnumerable<ChampionshipViewModel> GetAll()
        {
            return _championshipRepository.GetAll().ProjectTo<ChampionshipViewModel>(_mapper.ConfigurationProvider);
        }

        public ChampionshipViewModel GetById(int id)
        {
            return _mapper.Map<ChampionshipViewModel>(_championshipRepository.GetById(id));
        }

        public void Update(ChampionshipViewModel championshipViewModel)
        {
            _championshipRepository.Update(_mapper.Map<Championship>(championshipViewModel));

            //var updateCommand = _mapper.Map<UpdateCustomerCommand>(championshipViewModel);
            //Bus.SendCommand(updateCommand);
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
