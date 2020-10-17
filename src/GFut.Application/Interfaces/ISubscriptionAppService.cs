using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface ISubscriptionAppService : IDisposable
    {
        IEnumerable<SubscriptionViewModel> GetAll();
        IEnumerable<SubscriptionViewModel> GetSubscriptionByChampionshipId(int id);

        SubscriptionViewModel GetById(int id);
        void Update(SubscriptionViewModel subscriptionViewModel);
        void Add(SubscriptionViewModel subscriptionViewModel);
        void Remove(int id);
    }
}
