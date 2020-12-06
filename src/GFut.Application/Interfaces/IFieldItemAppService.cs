using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IFieldItemAppService : IDisposable
    {
        Task<IEnumerable<FieldItemViewModel>> GetAll();
        Task<IEnumerable<FieldItemViewModel>> GetFieldItemByFieldId(int FieldId);
        Task<FieldItemViewModel> GetById(int id);
        void Update(FieldItemViewModel fieldViewModel);
        void Add(FieldItemViewModel fieldViewModel);
        void Remove(int id);
    }
}
