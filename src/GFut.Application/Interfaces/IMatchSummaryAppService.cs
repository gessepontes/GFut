using GFut.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IMatchSummaryAppService : IDisposable
    {
        Task<MatchSummaryViewModel> GetById(int id);
        void Update(MatchSummaryViewModel subscriptionViewModel);
    }
}
