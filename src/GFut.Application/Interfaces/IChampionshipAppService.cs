using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IChampionshipAppService : IDisposable
    {
        Task<IEnumerable<ChampionshipViewModel>> GetGroupChampionship();
        Task<IEnumerable<ChampionshipViewModel>> GetAll();
        Task<ChampionshipViewModel> GetById(int id);
        void Update(ChampionshipViewModel championshipViewModel);
        void Add(ChampionshipViewModel championshipViewModel);
        void Remove(int id);
    }
}
