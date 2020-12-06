using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IFieldAppService : IDisposable
    {
        Task<IEnumerable<FieldViewModel>> GetAll();
        Task<FieldViewModel> GetById(int id);
        void Update(FieldViewModel fieldViewModel);
        void Add(FieldViewModel fieldViewModel);
        void Remove(int id);
    }
}
