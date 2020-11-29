using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using static GFut.Domain.Others.Enum;
using GFut.Domain.Others;

namespace GFut.Application.Services
{
    public class MatchSummaryAppService : IMatchSummaryAppService
    {
        private readonly IChampionshipRepository _championshipRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IGroupChampionshipRepository _groupChampionshipRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public MatchSummaryAppService(IMapper mapper,
            ISubscriptionRepository subscriptionRepository, 
            IChampionshipRepository championshipRepository,
            IGroupChampionshipRepository groupChampionshipRepository,
            IHostingEnvironment env)
        {
            _championshipRepository = championshipRepository;
            _subscriptionRepository = subscriptionRepository;
            _groupChampionshipRepository = groupChampionshipRepository;
            _mapper = mapper;
            _env = env;
        }

        public MatchSummaryViewModel GetById(int id)
        {
            return null; // _mapper.Map<MatchChampionshipViewModel>(_matchChampionshipRepository.GetById(id));
        }

        public void Update(MatchSummaryViewModel matchSummaryViewModel)
        {
            //_matchChampionshipRepository.Update(_mapper.Map<MatchChampionship>(matchChampionshipViewModel));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
