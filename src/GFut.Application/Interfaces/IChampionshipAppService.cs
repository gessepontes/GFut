using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IChampionshipAppService : IDisposable
    {
        IEnumerable<ChampionshipViewModel> GetAll();
        ChampionshipViewModel GetById(int id);
        void Update(ChampionshipViewModel championshipViewModel);
        void Remove(int id);
    }
}
