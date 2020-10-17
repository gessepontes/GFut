using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IPersonAppService : IDisposable
    {
        void Register(PersonViewModel personViewModel);
        IEnumerable<PersonViewModel> GetAll();
        IEnumerable<PersonViewModel> GetPersonChampionshipDrop();
        IEnumerable<PersonViewModel> GetPersonFieldDrop();

        IEnumerable<PersonViewModel> GetPersonAllDrop();

        PersonViewModel GetById(int id);
        void Update(PersonViewModel personViewModel);
        void Remove(int id);
    }
}
