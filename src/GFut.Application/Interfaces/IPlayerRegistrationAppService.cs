using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IPlayerRegistrationAppService : IDisposable
    {
        Task<IEnumerable<PlayerRegistrationViewModel>> GetAll();
        Task<IEnumerable<PlayerRegistrationViewModel>> GetPlayerRegistrationByChampionshipId(int id);
        Task<PlayerRegistrationViewModel> GetById(int id);
        void Update(PlayerRegistrationViewModel playerRegistrationViewModel);
        void Add(PlayerRegistrationViewModel playerRegistrationViewModel);
        void Remove(int id);
    }
}
