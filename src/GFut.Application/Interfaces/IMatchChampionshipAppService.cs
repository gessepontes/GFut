using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IMatchChampionshipAppService : IDisposable
    {
        IEnumerable<MatchChampionshipViewModel> GetAll();
        IEnumerable<MatchChampionshipViewModel> GetMatchChampionshipByChampionshipId(int id);
        MatchChampionshipViewModel GetById(int id);
        void Update(MatchChampionshipViewModel subscriptionViewModel);
        void Add(MatchChampionshipViewModel subscriptionViewModel);
        void Remove(int id);

        void AutomaticMatchChampionship(int championshipId, int groupId);

    }
}
