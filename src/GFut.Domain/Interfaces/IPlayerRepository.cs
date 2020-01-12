using GFut.Domain.Models;
using System.Collections.Generic;

namespace GFut.Domain.Interfaces
{
    public interface IPlayerRepository : IRepository<Player> {
        IEnumerable<Player> GetPlayerTeam(int id);
    }
}
