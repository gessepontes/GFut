using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IFieldAppService : IDisposable
    {
        IEnumerable<FieldViewModel> GetAll();
        FieldViewModel GetById(int id);
        void Update(FieldViewModel championshipViewModel);
        void Remove(int id);
    }
}
