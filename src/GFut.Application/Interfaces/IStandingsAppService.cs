using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IStandingsAppService : IDisposable
    {
        Task<IEnumerable<List<StandingsViewModel>>> GetStandingsByChampionshipId(int id);
    }
}
