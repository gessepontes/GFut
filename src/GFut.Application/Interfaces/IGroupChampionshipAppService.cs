using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IGroupChampionshipAppService : IDisposable
    {
        Task<IEnumerable<GroupChampionshipViewModel>> GetAll();
        Task<IEnumerable<GroupChampionshipViewModel>> GetGroupChampionshipByChampionshipId(int id);
        Task<GroupChampionshipViewModel> GetById(int id);
        void Update(GroupChampionshipViewModel subscriptionViewModel);
        void Add(GroupChampionshipViewModel subscriptionViewModel);
        void Remove(int id);

        void AutomaticGroupChampionship(int championshipId, int quantity);

    }
}
