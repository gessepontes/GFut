using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IFieldItemAppService : IDisposable
    {
        IEnumerable<FieldItemViewModel> GetAll();
        IEnumerable<FieldItemViewModel> GetFieldItemByFieldId(int FieldId);
        FieldItemViewModel GetById(int id);
        void Update(FieldItemViewModel fieldViewModel);
        void Add(FieldItemViewModel fieldViewModel);
        void Remove(int id);
    }
}
