using GFut.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface IChampionshipRepository : IRepository<Championship> {
        Task<IEnumerable<Championship>> GetPreInscription();
        Task<IEnumerable<Championship>> GetChampionshipInscription(int id);
    }
}
