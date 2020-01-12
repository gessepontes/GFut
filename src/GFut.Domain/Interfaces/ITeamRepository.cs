using GFut.Domain.Models;
using System.Collections.Generic;

namespace GFut.Domain.Interfaces
{
    public interface ITeamRepository : IRepository<Team> {
        IEnumerable<Team> GetTeamPerson(int id);
    }
}
