using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using GFut.Domain.Models;
using static GFut.Domain.Others.Enum;

namespace GFut.Application.Services
{
    public class StandingsAppService : IStandingsAppService
    {
        private readonly IMatchChampionshipRepository _matchChampionshipRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IGroupChampionshipRepository _groupChampionshipRepository;
        private readonly IChampionshipRepository _championshipRepository;
        private readonly IHostingEnvironment _env;


        public StandingsAppService(IMatchChampionshipRepository matchChampionshipRepository, 
            ISubscriptionRepository subscriptionRepository, 
            IGroupChampionshipRepository groupChampionshipRepository,
            IChampionshipRepository championshipRepository,
            IHostingEnvironment env)
        {
            _matchChampionshipRepository = matchChampionshipRepository;
            _subscriptionRepository = subscriptionRepository;
            _groupChampionshipRepository = groupChampionshipRepository;
            _championshipRepository = championshipRepository;
            _env = env;
        }

        public IEnumerable<List<StandingsViewModel>> GetStandingsByChampionshipId(int id)
        {

            List<List<StandingsViewModel>> standingsList = new List<List<StandingsViewModel>>();
            List<Subscription> subscriptionList = new List<Subscription>();

            var championship = _championshipRepository.GetById(id);

            if (championship.ChampionshipType == ChampionshipType.PontosCorridos)
            {
                subscriptionList = _subscriptionRepository.GetAll().Where(p => p.ChampionshipId == id).OrderBy(p => p.Team.Name).ToList();

                standingsList.Add(GetStandingsBySubscriptions(subscriptionList));
            }
            else
            {
                foreach (Group group in (Group[])Enum.GetValues(typeof(Group)))
                {
                    var groupChampionship = _groupChampionshipRepository.GetAll().Where(p => p.Subscription.ChampionshipId == id && p.GroupId == group);

                    foreach (var item in groupChampionship)
                    {
                        subscriptionList.Add(item.Subscription);
                    }

                    if (subscriptionList.Count() == 0)
                        break;

                    standingsList.Add(GetStandingsBySubscriptions(subscriptionList));

                    subscriptionList.Clear();
                }
            }

            return standingsList;
        }

        private List<StandingsViewModel> GetStandingsBySubscriptions(List<Subscription> subscriptionList) {

            List<StandingsViewModel> standingsList = new List<StandingsViewModel>();

            int points, played, won, drawn, lost, goalsFor, goalsAgainst, goalsDifference, percentage;

            foreach (var item in subscriptionList)
            {
                points = 0;
                played = 0;
                won = 0;
                drawn = 0;
                lost = 0;
                goalsFor = 0;
                goalsAgainst = 0;
                goalsDifference = 0;
                percentage = 0;

                List<MatchChampionship> _matchChampionshipList = _matchChampionshipRepository.GetAll().Where(p => p.Calculate == true && (p.HomeSubscriptionId == item.Id || p.GuestSubscriptionId == item.Id)).ToList();

                foreach (var item2 in _matchChampionshipList)
                {
                    played += 1;

                    if (item.Id == item2.Id)
                    {
                        if (item2.HomePoints > item2.GuestPoints)
                        {
                            points += 3;
                            won += 1;
                            goalsFor += item2.HomePoints;
                            goalsAgainst += item2.GuestPoints;
                        }
                        else if (item2.HomePoints < item2.GuestPoints)
                        {
                            lost += 1;
                            goalsFor += item2.HomePoints;
                            goalsAgainst += item2.GuestPoints;
                        }
                        else if (item2.HomePoints == item2.GuestPoints)
                        {
                            points += 1;
                            drawn += 1;
                            goalsFor += item2.HomePoints;
                            goalsAgainst += item2.GuestPoints;
                        }
                    }
                    else
                    {
                        if (item2.HomePoints > item2.GuestPoints)
                        {
                            lost += 1;
                            goalsFor += item2.GuestPoints;
                            goalsAgainst += item2.HomePoints;
                        }
                        else if (item2.HomePoints < item2.GuestPoints)
                        {
                            points += 3;
                            won += 1;
                            goalsFor += item2.GuestPoints;
                            goalsAgainst += item2.HomePoints;
                        }

                        else if (item2.HomePoints == item2.GuestPoints)
                        {
                            points += 1;
                            drawn += 1;
                            goalsFor += item2.GuestPoints;
                            goalsAgainst += item2.HomePoints;
                        }
                    }
                }

                goalsDifference = goalsFor - goalsAgainst;

                if (points != 0)
                {
                    percentage = (points * 100) / (played * 3);
                }

                StandingsViewModel standings = new StandingsViewModel
                {
                    Name = item.Team.Name,
                    Played = played,
                    Points = points,
                    Won = won,
                    Drawn = drawn,
                    Lost = lost,
                    GoalsFor = goalsFor,
                    GoalsAgainst = goalsAgainst,
                    GoalsDifference = goalsDifference,
                    Percentage = percentage
                };

                standingsList.Add(standings);

            }

            return standingsList.OrderByDescending(p => p.Points).ThenByDescending(p => p.Won).ThenByDescending(p => p.GoalsDifference).ThenByDescending(p => p.GoalsFor).ToList(); ;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
