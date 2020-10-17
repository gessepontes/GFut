using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IPlayerRegistrationAppService : IDisposable
    {
        IEnumerable<PlayerRegistrationViewModel> GetAll();

        IEnumerable<PlayerRegistrationViewModel> GetPlayerRegistrationByChampionshipId(int id);

        PlayerRegistrationViewModel GetById(int id);
        void Update(PlayerRegistrationViewModel playerRegistrationViewModel);
        void Add(PlayerRegistrationViewModel playerRegistrationViewModel);
        void Remove(int id);
    }
}
