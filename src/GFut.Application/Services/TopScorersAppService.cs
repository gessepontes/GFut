using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using GFut.Domain.Models;

namespace GFut.Application.Services
{
    public class TopScorersAppService : ITopScorersAppService
    {
        private readonly IMatchPlayerChampionshipRepository _matchPlayerChampionshipsRepository;
        private readonly IHostingEnvironment _env;


        public TopScorersAppService(IMatchPlayerChampionshipRepository matchPlayerChampionshipsRepository,
            IHostingEnvironment env)
        {
            _matchPlayerChampionshipsRepository = matchPlayerChampionshipsRepository;
            _env = env;
        }

        public IEnumerable<TopScorersViewModel> GetTopScorersByChampionshipId(int id)
        {

            List<TopScorersViewModel> topScorersList = new List<TopScorersViewModel>();

            var result = from o in _matchPlayerChampionshipsRepository.GetAll()
                         where o.PlayerRegistration.Subscription.ChampionshipId  == id
                         let k = new
                         {
                             Player = o.PlayerRegistration.Player.Name,
                             Team = o.PlayerRegistration.Player.Team.Name,
                         }
                         group o by k into t
                         select new TopScorersViewModel
                         {
                             Player = t.Key.Player,
                             Team = t.Key.Team,
                             Goals = t.Sum(p => p.Points) 
                         };


            //topScorersList = result.OrderByDescending(p => p.Goals);

            return topScorersList;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
