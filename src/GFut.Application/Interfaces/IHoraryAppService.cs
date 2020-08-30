using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IHoraryAppService : IDisposable
    {
        IEnumerable<HoraryViewModel> GetAll();
        IEnumerable<HoraryViewModel> GetSearchHorary(string search);
        HoraryViewModel GetById(int id);
        void Update(HoraryViewModel fieldViewModel);
        void Add(HoraryViewModel fieldViewModel);
        void Remove(int id);
    }
}
