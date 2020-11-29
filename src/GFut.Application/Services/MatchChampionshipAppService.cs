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
    public class MatchChampionshipAppService : IMatchChampionshipAppService
    {
        private readonly IMatchChampionshipRepository _matchChampionshipRepository;
        private readonly IChampionshipRepository _championshipRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IGroupChampionshipRepository _groupChampionshipRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public MatchChampionshipAppService(IMapper mapper, IMatchChampionshipRepository matchChampionshipRepository, 
            ISubscriptionRepository subscriptionRepository, 
            IChampionshipRepository championshipRepository,
            IGroupChampionshipRepository groupChampionshipRepository,
            IHostingEnvironment env)
        {
            _matchChampionshipRepository = matchChampionshipRepository;
            _championshipRepository = championshipRepository;
            _subscriptionRepository = subscriptionRepository;
            _groupChampionshipRepository = groupChampionshipRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<MatchChampionshipViewModel> GetAll()
        {
            return _matchChampionshipRepository.GetAll().ProjectTo<MatchChampionshipViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<MatchChampionshipViewModel> GetMatchChampionshipByChampionshipId(int id)
        {
            var _dados = _matchChampionshipRepository.GetAll().Where(p => p.HomeSubscription.ChampionshipId == id || p.GuestSubscription.ChampionshipId == id).ProjectTo<MatchChampionshipViewModel>(_mapper.ConfigurationProvider).ToList();

            _dados.ForEach(p => p.HomeSubscription = _subscriptionRepository.GetAll().Where(x => x.Id == p.HomeSubscriptionId).ProjectTo<SubscriptionViewModel>(_mapper.ConfigurationProvider).FirstOrDefault());

            return _dados.OrderBy(p => p.Round);
        }

        public MatchChampionshipViewModel GetById(int id)
        {
            return _mapper.Map<MatchChampionshipViewModel>(_matchChampionshipRepository.GetById(id));
        }

        public void Update(MatchChampionshipViewModel matchChampionshipViewModel)
        {
            _matchChampionshipRepository.Update(_mapper.Map<MatchChampionship>(matchChampionshipViewModel));
        }

        public void Remove(int id)
        {
            _matchChampionshipRepository.Remove(id);
        }

        public void AutomaticMatchChampionship(int championshipId, int groupId)
        {
            Random rnd = new Random();
            int quantityTeam = 0;
            int round = 0;
            int count = 0;
            int turno = 0;
            int fieldId = 0;

            List<int> teamSubscription = new List<int>();

            string[] matchs;
          

            var championship = _championshipRepository.GetById(championshipId);

            switch (championship.ChampionshipType)
            {
                case ChampionshipType.Grupos:
                    if (groupId == 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        var groupChampionship = _groupChampionshipRepository.GetAll().Where(p => p.GroupId == (Group)groupId && p.Subscription.ChampionshipId == championshipId).ToList();

                        foreach (var e in groupChampionship)
                        {
                            teamSubscription.Add(e.SubscriptionId);
                            fieldId = e.Subscription.Championship.FieldId;
                        }
                    }
                    break;
                case ChampionshipType.MataMata:
                    break;
                case ChampionshipType.PontosCorridos:
                    var subscriptions = _subscriptionRepository.GetAll().Where(p => p.ChampionshipId == championshipId);

                    foreach (var e in subscriptions)
                    {
                        teamSubscription.Add(e.Id);
                        fieldId = e.Championship.FieldId;
                    }
                    break;
                default:
                    break;
            }

            quantityTeam = teamSubscription.Count();

            if (quantityTeam % 2 == 0) { round = quantityTeam - 1; } else { round = quantityTeam; }

            if (championship.GoBack)
            {
                turno = 2;
                matchs = new string[Divers.CalculaFatorial(quantityTeam) / Divers.CalculaFatorial(quantityTeam - 2)];
            }
            else
            {
                turno = 1;
                matchs = new string[Divers.CalculaFatorial(quantityTeam) / Divers.CalculaFatorial(quantityTeam - 2) / 2];
            }

            count = 0;

            for (int t = 0; t < turno; t++)
            {
                for (int i = 0; i < quantityTeam; i++)
                { //For para caminhar entre os times
                    for (int j = i; j < quantityTeam; j++)
                    { //For para caminha entre os adversários
                        if (teamSubscription[i] != teamSubscription[j])
                        {
                            MatchChampionship matchChampionship = new MatchChampionship
                            {
                                HomeSubscriptionId = teamSubscription[i],
                                GuestSubscriptionId = teamSubscription[j],
                                HomePoints = 0,
                                GuestPoints = 0,
                                MatchDate = DateTime.Now,
                                RegisterDate = DateTime.Now,
                                StartTime = "",
                                Round = 0
                            };

                            _matchChampionshipRepository.Add(matchChampionship);

                            //Sumula sumula = new Sumula();

                            //sumula.IDPartidaCampeonato = partidaCampeonato.IDPartidaCampeonato;
                            //sumula.sObservacao = "";
                            //sumula.dDataCadastro = DateTime.Now;
                            //db.Sumula.Add(sumula);
                            //db.SaveChanges();
                        }
                        }
                    }
                }

            if (quantityTeam % 2 == 0)
            {
                OrdenaRodada(championshipId, teamSubscription);
            }
            else
            {
                List<int> timesInscritosNew = new List<int>();

                foreach (int e in teamSubscription)
                {
                    timesInscritosNew[count] = e;
                    count++;
                }

                timesInscritosNew[teamSubscription.Count()] = 10000000;

                OrdenaRodada(championshipId, timesInscritosNew);
            }
        }

        public void OrdenaRodada(int championshipId, List<int> teamSubscription)
        {
            int teamId = 0;
            int round = 0;
            int exitWhile = 0;
            bool save = true;
            bool saveA = true;
            
            List<int> teamSubscriptionNew = new List<int>();

            for (int i = 0; i < teamSubscription.Count() - 1; i++)
            {
                teamId = teamSubscription[i];

                var matchChampionship = _matchChampionshipRepository.GetAll().Where(p => p.HomeSubscriptionId == teamId || p.GuestSubscriptionId == teamId);

                foreach (var e in matchChampionship)
                {
                    teamSubscriptionNew.Add(e.Id);
                }

                round = 1;

                for (int j = 0; j < teamSubscriptionNew.Count(); j++)
                {
                    var matchChampionshipAdd = _matchChampionshipRepository.GetById(teamSubscriptionNew[j]);


                    if (round > teamSubscriptionNew.Count())
                    {
                        round = 1;
                    }

                    if (matchChampionshipAdd != null)
                    {
                        if (matchChampionshipAdd.Round == 0)
                        {
                            save = true;
                            exitWhile = 0;

                            while (save)
                            {
                                List<MatchChampionship> lpc = _matchChampionshipRepository.GetAll().Where(p =>p.Round == round && (p.HomeSubscriptionId == teamId || p.GuestSubscriptionId == teamId)).ToList();

                                if (lpc.Count() == 0)
                                {
                                    saveA = true;

                                    while (saveA)
                                    {
                                        List<MatchChampionship> lpcA = new List<MatchChampionship>();

                                        if (teamId == matchChampionshipAdd.HomeSubscriptionId)
                                        {
                                            lpcA = _matchChampionshipRepository.GetAll().Where(p => p.Round == round && (p.HomeSubscriptionId == matchChampionshipAdd.GuestSubscriptionId || p.GuestSubscriptionId == matchChampionshipAdd.GuestSubscriptionId)).ToList();
                                        }
                                        else
                                        {
                                            lpcA = _matchChampionshipRepository.GetAll().Where(p => p.Round == round && (p.HomeSubscriptionId == matchChampionshipAdd.HomeSubscriptionId || p.GuestSubscriptionId == matchChampionshipAdd.HomeSubscriptionId)).ToList();
                                        }


                                        if (lpcA.Count() == 0)
                                        {
                                            matchChampionshipAdd.Round = round;
                                            _matchChampionshipRepository.Update(matchChampionshipAdd);

                                            saveA = false;
                                            save = false;
                                        }
                                        else
                                        {
                                            saveA = true;
                                            round++;

                                            if (round > teamSubscriptionNew.Count())
                                            {
                                                saveA = false;
                                                save = false;
                                                round = 0;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    save = true;
                                    round++;

                                    if (round > teamSubscriptionNew.Count())
                                    {
                                        saveA = false;
                                        round = 0;
                                    }
                                }

                                exitWhile++;

                                if (exitWhile > 50)
                                {
                                    save = false;
                                }
                            }
                        }
                    }

                    round++;
                }
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(MatchChampionshipViewModel matchChampionshipViewModel)
        {
            _matchChampionshipRepository.Add(_mapper.Map<MatchChampionship>(matchChampionshipViewModel));
        }
    }
}
