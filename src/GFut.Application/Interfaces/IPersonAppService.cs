using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IPersonAppService : IDisposable
    {
        void Register(PersonViewModel personViewModel);
        Task<IEnumerable<PersonViewModel>> GetAll();
        Task<IEnumerable<PersonViewModel>> GetPersonChampionshipDrop();
        Task<IEnumerable<PersonViewModel>> GetPersonFieldDrop();
        Task<IEnumerable<PersonViewModel>> GetPersonAllDrop();
        Task<PersonViewModel> GetById(int id);
        void Update(PersonViewModel personViewModel);
        void Remove(int id);
    }
}

