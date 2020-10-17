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

namespace GFut.Application.Services
{
    public class SubscriptionAppService : ISubscriptionAppService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public SubscriptionAppService(IMapper mapper, ISubscriptionRepository subscriptionRepository, IHostingEnvironment env)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<SubscriptionViewModel> GetAll()
        {
            return _subscriptionRepository.GetAll().ProjectTo<SubscriptionViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<SubscriptionViewModel> GetSubscriptionByChampionshipId(int id)
        {
            return _subscriptionRepository.GetAll().Where(p => p.ChampionshipId == id).ProjectTo<SubscriptionViewModel>(_mapper.ConfigurationProvider);
        }

        public SubscriptionViewModel GetById(int id)
        {
            return _mapper.Map<SubscriptionViewModel>(_subscriptionRepository.GetById(id));
        }

        public void Update(SubscriptionViewModel subscriptionViewModel)
        {
            _subscriptionRepository.Update(_mapper.Map<Subscription>(subscriptionViewModel));
        }

        public void Remove(int id)
        {
            _subscriptionRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(SubscriptionViewModel subscriptionViewModel)
        {
            _subscriptionRepository.Add(_mapper.Map<Subscription>(subscriptionViewModel));
        }
    }
}
