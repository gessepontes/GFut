using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IFieldAppService : IDisposable
    {
        IEnumerable<FieldViewModel> GetAll();
        IEnumerable<FieldViewModel> GetSearchField(string search);
        FieldViewModel GetById(int id);
        void Update(FieldViewModel fieldViewModel);
        void Add(FieldViewModel fieldViewModel);
        void Remove(int id);
    }
}
