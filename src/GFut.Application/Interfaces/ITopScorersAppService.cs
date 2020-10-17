using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface ITopScorersAppService : IDisposable
    {
        IEnumerable<TopScorersViewModel> GetTopScorersByChampionshipId(int id);
    }
}
