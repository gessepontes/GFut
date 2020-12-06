using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IHoraryExtraAppService : IDisposable
    {
        Task<IEnumerable<HoraryExtraViewModel>> GetAll();
        Task<IEnumerable<HoraryExtraViewModel>> GetHoraryExtraByFieldId(int FieldId);
        Task<HoraryExtraViewModel> GetById(int id);
        void Update(HoraryExtraViewModel fieldViewModel);
        void Add(HoraryExtraViewModel fieldViewModel);
        void Remove(int id);
    }
}
