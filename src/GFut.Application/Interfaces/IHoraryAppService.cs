using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IHoraryAppService : IDisposable
    {
        Task<IEnumerable<HoraryViewModel>> GetAll();
        Task<IEnumerable<HoraryViewModel>> GetHoraryByFieldId(int fieldId);
        Task<IEnumerable<HoraryViewModel>> GetHoraryDrop(int type, int fieldItem, DateTime date, int horaryId);
        Task<HoraryViewModel> GetById(int id);
        void Update(HoraryViewModel fieldViewModel);
        void Add(HoraryViewModel fieldViewModel);
        void Remove(int id);
    }
}
