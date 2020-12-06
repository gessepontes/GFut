using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using GFut.Domain.Models;
using System.Threading.Tasks;

namespace GFut.Application.Services
{
    public class TopScorersAppService : ITopScorersAppService
    {
        private readonly IMatchPlayerChampionshipRepository _matchPlayerChampionshipsRepository;


        public TopScorersAppService(IMatchPlayerChampionshipRepository matchPlayerChampionshipsRepository)
        {
            _matchPlayerChampionshipsRepository = matchPlayerChampionshipsRepository;
        }

        public async Task<IEnumerable<TopScorersViewModel>> GetTopScorersByChampionshipId(int id)
        {

            List<TopScorersViewModel> topScorersList = new List<TopScorersViewModel>();
            var resultMatch = await _matchPlayerChampionshipsRepository.GetAll();

            var result = from o in resultMatch
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
