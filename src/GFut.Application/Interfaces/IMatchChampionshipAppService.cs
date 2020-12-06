using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IMatchChampionshipAppService : IDisposable
    {
        Task<IEnumerable<MatchChampionshipViewModel>> GetAll();
        Task<IEnumerable<MatchChampionshipViewModel>> GetMatchChampionshipByChampionshipId(int id);
        Task<MatchChampionshipViewModel> GetById(int id);
        void Update(MatchChampionshipViewModel subscriptionViewModel);
        void Add(MatchChampionshipViewModel subscriptionViewModel);
        void Remove(int id);

        void AutomaticMatchChampionship(int championshipId, int groupId);

    }
}
