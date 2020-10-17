using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using GFut.Domain.Models;
using static GFut.Domain.Others.Enum;

namespace GFut.Application.Services
{
    public class SuspendedPlayersAppService : ISuspendedPlayersAppService
    {
        private readonly IMatchPlayerChampionshipRepository _matchPlayerChampionshipsRepository;
        private readonly IChampionshipRepository _championshipRepository;
        private readonly IHostingEnvironment _env;


        public SuspendedPlayersAppService(IMatchPlayerChampionshipRepository matchPlayerChampionshipsRepository,
            IChampionshipRepository championshipRepository,
            IHostingEnvironment env)
        {
            _matchPlayerChampionshipsRepository = matchPlayerChampionshipsRepository;
            _championshipRepository = championshipRepository;

            _env = env;
        }

        public IEnumerable<SuspendedPlayersViewModel> GetSuspendedPlayersByChampionshipId(int id, int rodada)
        {

            List<SuspendedPlayersViewModel> suspendedPlayersList = new List<SuspendedPlayersViewModel>();

            var championship = _championshipRepository.GetById(id);

            rodada -= 1;

            List<MatchPlayerChampionship> partidasCartaoAmarelo, partidasCartaoVermelho;

            if (championship.RefereeType == RefereeType.Campo)
            {
                List<SuspendedPlayersViewModel> jsl = new List<SuspendedPlayersViewModel>();

                for (int i = 1; i <= rodada; i++)
                {
                    partidasCartaoAmarelo = _matchPlayerChampionshipsRepository.GetAll()
                                        .Where(p => p.Card == CardType.Yellow || p.Card == CardType.YellowSecond || p.Card == CardType.RedYellow)
                                        .Where(s => s.MatchChampionship.Round == i && s.PlayerRegistration.Subscription.ChampionshipId == id).ToList();

                    foreach (var item in partidasCartaoAmarelo)
                    {
                        suspendedPlayersList.Add(new SuspendedPlayersViewModel { Id = item.PlayerRegistrationId, Player = item.PlayerRegistration.Player.Name, Team = item.PlayerRegistration.Subscription.Team.Name });
                    }

                    var groupJogador = suspendedPlayersList.GroupBy(p => p.Id).Select(grp => new
                    {
                        Id = grp.Key,
                        grp.First().Player,
                        grp.First().Team
                    })
                   .ToArray();

                    foreach (var item in groupJogador)
                    {
                        int qntCartaoJogador = suspendedPlayersList.Where(p => p.Id == item.Id).ToList().Count;

                        if (qntCartaoJogador >= 3)
                        {
                            if (qntCartaoJogador % 3 == 0)
                            {
                                SuspendedPlayersViewModel suspendedPlayersViewModel = new SuspendedPlayersViewModel
                                {
                                    Player = item.Player,
                                    Team = item.Team
                                };

                                jsl.Add(suspendedPlayersViewModel);

                                suspendedPlayersList.RemoveAll(jc => jc.Id == item.Id);
                            }
                        }
                    }

                    partidasCartaoVermelho = _matchPlayerChampionshipsRepository.GetAll()
                                        .Where(p => p.Card == CardType.Red || p.Card == CardType.YellowSecond || p.Card == CardType.RedYellow)
                                        .Where(s => s.MatchChampionship.Round == i && s.PlayerRegistration.Subscription.ChampionshipId == id).ToList();

                    foreach (var item in partidasCartaoVermelho)
                    {
                        SuspendedPlayersViewModel suspendedPlayersViewModel = new SuspendedPlayersViewModel
                        {
                            Player = item.PlayerRegistration.Player.Name,
                            Team = item.PlayerRegistration.Subscription.Team.Name
                        };

                        jsl.Add(suspendedPlayersViewModel);
                    }
                }

                suspendedPlayersList = jsl;
            }
            else
            {
                partidasCartaoVermelho = _matchPlayerChampionshipsRepository.GetAll()
                                    .Where(p => p.Card == CardType.Red || p.Card == CardType.YellowSecond || p.Card == CardType.RedYellow)
                                    .Where(s => s.MatchChampionship.Round == rodada && s.PlayerRegistration.Subscription.ChampionshipId == id).ToList();

                foreach (var item in partidasCartaoVermelho)
                {
                    SuspendedPlayersViewModel suspendedPlayersViewModel = new SuspendedPlayersViewModel
                    {
                        Player = item.PlayerRegistration.Player.Name,
                        Team = item.PlayerRegistration.Subscription.Team.Name
                    };

                    suspendedPlayersList.Add(suspendedPlayersViewModel);
                }
            }

            return suspendedPlayersList;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
