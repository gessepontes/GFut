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
using System.Threading.Tasks;

namespace GFut.Application.Services
{
    public class SubscriptionAppService : ISubscriptionAppService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public SubscriptionAppService(IMapper mapper, ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubscriptionViewModel>> GetAll()
        {
            var result = await _subscriptionRepository.GetAll();
            return result.Select(_mapper.Map<SubscriptionViewModel>);
        }

        public async Task<IEnumerable<SubscriptionViewModel>> GetSubscriptionByChampionshipId(int id)
        {
            var result = await _subscriptionRepository.GetAll();
            return result.Where(p => p.ChampionshipId == id).Select(_mapper.Map<SubscriptionViewModel>); 
        }

        public async Task<SubscriptionViewModel> GetById(int id)
        {
            return _mapper.Map<SubscriptionViewModel>(await _subscriptionRepository.GetById(id));
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
