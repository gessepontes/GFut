using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IPersonAppService : IDisposable
    {
        void Add(PersonViewModel personViewModel);
        Task<IEnumerable<PersonViewModel>> GetAll();
        Task<IEnumerable<PersonViewModel>> GetPersonChampionshipDrop();
        Task<IEnumerable<PersonViewModel>> GetPersonFieldDrop();
        Task<IEnumerable<PersonViewModel>> GetPersonAllDrop();
        Task<PersonViewModel> GetById(int id);
        void Update(PersonViewModel personViewModel);
        void UpdateProfile(PersonViewModel personViewModel);

        Task<PersonViewModel> GetProfileTeam(Person person);

        void Remove(int id);
    }
}

