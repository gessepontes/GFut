using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IGroupChampionshipAppService : IDisposable
    {
        IEnumerable<GroupChampionshipViewModel> GetAll();
        IEnumerable<GroupChampionshipViewModel> GetGroupChampionshipByChampionshipId(int id);

        GroupChampionshipViewModel GetById(int id);
        void Update(GroupChampionshipViewModel subscriptionViewModel);
        void Add(GroupChampionshipViewModel subscriptionViewModel);
        void Remove(int id);

        void AutomaticGroupChampionship(int championshipId, int quantity);

    }
}
