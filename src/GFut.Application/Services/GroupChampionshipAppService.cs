﻿using GFut.Application.Interfaces;
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

namespace GFut.Application.Services
{
    public class GroupChampionshipAppService : IGroupChampionshipAppService
    {
        private readonly IGroupChampionshipRepository _groupChampionshipRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public GroupChampionshipAppService(IMapper mapper, IGroupChampionshipRepository groupChampionshipRepository, ISubscriptionRepository subscriptionRepository, IHostingEnvironment env)
        {
            _groupChampionshipRepository = groupChampionshipRepository;
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<GroupChampionshipViewModel> GetAll()
        {
            return _groupChampionshipRepository.GetAll().ProjectTo<GroupChampionshipViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<GroupChampionshipViewModel> GetGroupChampionshipByChampionshipId(int id)
        {
            return _groupChampionshipRepository.GetAll().Where(p => p.Subscription.ChampionshipId == id).ProjectTo<GroupChampionshipViewModel>(_mapper.ConfigurationProvider);
        }

        public GroupChampionshipViewModel GetById(int id)
        {
            return _mapper.Map<GroupChampionshipViewModel>(_groupChampionshipRepository.GetById(id));
        }

        public void Update(GroupChampionshipViewModel groupChampionshipViewModel)
        {
            _groupChampionshipRepository.Update(_mapper.Map<GroupChampionship>(groupChampionshipViewModel));
        }

        public void Remove(int id)
        {
            _groupChampionshipRepository.Remove(id);
        }

        public void AutomaticGroupChampionship(int championshipId, int quantity)
        {
            var groupChampionship = _groupChampionshipRepository.GetAll().Where(p => p.Subscription.ChampionshipId == championshipId);
            int quantityGroupChampionship = groupChampionship.Count();

            if (quantityGroupChampionship > 0)
            {
                throw new Exception();
            }

            Random randNum = new Random();

            int quantityTeam = 0;
            int quantityGroup = 0;
            int count = 0;

            var subscriptions = _subscriptionRepository.GetAll().Where(p => p.ChampionshipId == championshipId);
            var quantitySubscription = subscriptions.Count();

            int[] times = new int[quantitySubscription];

            foreach (var e in subscriptions)
            {
                times[count] = e.Id;
                count++;
            }

            quantityTeam = times.Count();

            if (quantityTeam % quantity == 0)
            {
                quantityGroup = quantityTeam / quantity;
            }
            else
            {
                quantityGroup = (quantityTeam / quantity) + 1;
            }

            count = 0;

            for (int i = 1; i <= quantityGroup; i++)
            {
                for (int j = 1; j <= quantity; j++)
                {
                    GroupChampionship groupChampionshipAdd = new GroupChampionship
                    {
                        SubscriptionId = times[randNum.Next(0, quantityTeam - 1)],
                        GroupId = (Group)i,
                        RegisterDate = DateTime.Now
                    };

                    var championshipRepositoryCount = _groupChampionshipRepository.GetAll().Where(p => p.SubscriptionId == groupChampionshipAdd.SubscriptionId).Count();

                    if (championshipRepositoryCount == 0)
                    {
                        _groupChampionshipRepository.Add(groupChampionshipAdd);
                    }
                    else
                    {
                        if (i == quantityGroup)
                        {
                            for (int z = 0; z < quantityTeam; z++)
                            {
                                GroupChampionship lastGroupChampionship = new GroupChampionship
                                {
                                    SubscriptionId = times[z],
                                    GroupId = (Group)i,
                                    RegisterDate = DateTime.Now
                                };

                                var lastChampionshipRepositoryCount = _groupChampionshipRepository.GetAll().Where(p => p.SubscriptionId == lastGroupChampionship.SubscriptionId).Count();

                                if (lastChampionshipRepositoryCount == 0)
                                {
                                    _groupChampionshipRepository.Add(lastGroupChampionship);
                                }

                            }

                            return;
                        }

                        j -= 1;
                    }

                }
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(GroupChampionshipViewModel groupChampionshipViewModel)
        {
            _groupChampionshipRepository.Add(_mapper.Map<GroupChampionship>(groupChampionshipViewModel));
        }
    }
}
