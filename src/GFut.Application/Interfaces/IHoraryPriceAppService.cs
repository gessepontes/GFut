using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IHoraryPriceAppService : IDisposable
    {
        Task<IEnumerable<HoraryPriceViewModel>> GetAll();
        Task<IEnumerable<HoraryPriceViewModel>> GetSearchHoraryPrice(string search);
        Task<IEnumerable<HoraryPriceViewModel>> GetHoraryPriceByFieldId(int FieldId);
        Task<HoraryPriceViewModel> GetById(int id);
        void Update(HoraryPriceViewModel fieldViewModel);
        void Add(HoraryPriceViewModel fieldViewModel);
        void Remove(int id);
    }
}
