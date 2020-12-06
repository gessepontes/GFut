using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface ISubscriptionAppService : IDisposable
    {
        Task<IEnumerable<SubscriptionViewModel>> GetAll();
        Task<IEnumerable<SubscriptionViewModel>> GetSubscriptionByChampionshipId(int id);
        Task<SubscriptionViewModel> GetById(int id);
        void Update(SubscriptionViewModel subscriptionViewModel);
        void Add(SubscriptionViewModel subscriptionViewModel);
        void Remove(int id);
    }
}
