using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IPlayerAppService : IDisposable
    {
        Task<IEnumerable<PlayerViewModel>> GetAll();
        Task<PlayerViewModel> GetById(int id);
        void Add(PlayerViewModel playerViewModel);
        void Update(PlayerViewModel playerViewModel);
        void Remove(int id);
        Task<IEnumerable<PlayerViewModel>> GetPlayerTeam(int id);
        Task<IEnumerable<PlayerViewModel>> GetPlayerTeamByIdSubscription(int IdSubscription);
    }
}
