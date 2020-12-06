using GFut.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface ITeamRepository : IRepository<Team> {
       Task<IEnumerable<Team>> GetTeamPerson(int id);
    }
}
