using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface ISchedulingAppService : IDisposable
    {
        Task<IEnumerable<SchedulingViewModel>> GetAll();
        Task<IEnumerable<SchedulingViewModel>> GetSchedulingByFieldId(int FieldId);
        Task<SchedulingViewModel> GetById(int id);
        void Update(SchedulingViewModel fieldViewModel);
        void Add(SchedulingViewModel fieldViewModel);
        void Remove(int id);
    }
}
