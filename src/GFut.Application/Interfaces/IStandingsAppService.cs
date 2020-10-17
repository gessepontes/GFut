using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IStandingsAppService : IDisposable
    {
        IEnumerable<List<StandingsViewModel>> GetStandingsByChampionshipId(int id);
    }
}
