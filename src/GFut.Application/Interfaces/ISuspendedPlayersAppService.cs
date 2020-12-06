using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface ISuspendedPlayersAppService : IDisposable
    {
        Task<IEnumerable<SuspendedPlayersViewModel>> GetSuspendedPlayersByChampionshipId(int id, int rodada);
    }
}
