using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface ITeamAppService : IDisposable
    {
        IEnumerable<TeamViewModel> GetAll();
        TeamViewModel GetById(int id);
        void Add(TeamViewModel teamViewModel);
        void Update(TeamViewModel teamViewModel);
        void Status(int id);
        void Remove(int id);
        IEnumerable<TeamViewModel> GetTeamPerson(int id);
        IEnumerable<TeamViewModel> GetSearchTeamPerson(int id, string search);

    }
}
