using GFut.Application.ViewModels;
using System;

namespace GFut.Application.Interfaces
{
    public interface IMatchSummaryAppService : IDisposable
    {
        MatchSummaryViewModel GetById(int id);
        void Update(MatchSummaryViewModel subscriptionViewModel);
    }
}
