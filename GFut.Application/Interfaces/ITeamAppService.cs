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
        void Remove(int id);
    }
}
