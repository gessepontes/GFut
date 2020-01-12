using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IPlayerAppService : IDisposable
    {
        IEnumerable<PlayerViewModel> GetAll();
        PlayerViewModel GetById(int id);
        void Add(PlayerViewModel playerViewModel);
        void Update(PlayerViewModel playerViewModel);
        void Remove(int id);
    }
}
