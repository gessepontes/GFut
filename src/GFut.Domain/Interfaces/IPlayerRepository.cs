using GFut.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<IEnumerable<Player>> GetPlayerTeam(int id);
        Task<IEnumerable<Player>> GetPlayerTeamByIdSubscription(int id);
    }
}
