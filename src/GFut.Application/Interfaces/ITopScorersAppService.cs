using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface ITopScorersAppService : IDisposable
    {
        Task<IEnumerable<TopScorersViewModel>> GetTopScorersByChampionshipId(int id);
    }
}
