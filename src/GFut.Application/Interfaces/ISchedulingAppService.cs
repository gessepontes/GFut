using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface ISchedulingAppService : IDisposable
    {
        IEnumerable<SchedulingViewModel> GetAll();
        IEnumerable<SchedulingViewModel> GetSearchScheduling(string search);
        IEnumerable<SchedulingViewModel> GetSchedulingByFieldId(int FieldId);
        SchedulingViewModel GetById(int id);
        void Update(SchedulingViewModel fieldViewModel);
        void Add(SchedulingViewModel fieldViewModel);
        void Remove(int id);
    }
}
