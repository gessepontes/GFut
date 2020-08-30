using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IPersonAppService : IDisposable
    {
        void Register(PersonViewModel personViewModel);
        IEnumerable<PersonViewModel> GetAll();
        IEnumerable<PersonViewModel> GetPersonCampeonato();

        PersonViewModel GetById(int id);
        void Update(PersonViewModel personViewModel);
        void Remove(int id);
    }
}
