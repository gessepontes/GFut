using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IHoraryPriceAppService : IDisposable
    {
        IEnumerable<HoraryPriceViewModel> GetAll();
        IEnumerable<HoraryPriceViewModel> GetSearchHoraryPrice(string search);
        HoraryPriceViewModel GetById(int id);
        void Update(HoraryPriceViewModel fieldViewModel);
        void Add(HoraryPriceViewModel fieldViewModel);
        void Remove(int id);
    }
}
