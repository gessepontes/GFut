using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface ITeamAppService : IDisposable
    {
        Task<IEnumerable<TeamViewModel>> GetAll();
        Task<TeamViewModel> GetById(int id);
        void Add(TeamViewModel teamViewModel);
        void Update(TeamViewModel teamViewModel);
        void Status(int id);
        void Remove(int id);
        Task<IEnumerable<TeamViewModel>> GetTeamPerson(int id);
    }
}
