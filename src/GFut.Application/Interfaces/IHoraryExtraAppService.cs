using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IHoraryExtraAppService : IDisposable
    {
        IEnumerable<HoraryExtraViewModel> GetAll();
        IEnumerable<HoraryExtraViewModel> GetSearchHoraryExtra(string search);
        HoraryExtraViewModel GetById(int id);
        void Update(HoraryExtraViewModel fieldViewModel);
        void Add(HoraryExtraViewModel fieldViewModel);
        void Remove(int id);
    }
}
