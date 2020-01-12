using GFut.Domain.Models;
using System.Collections.Generic;

namespace GFut.Domain.Interfaces
{
    public interface IChampionshipRepository : IRepository<Championship> {
        IEnumerable<Championship> GetPreInscription();
        IEnumerable<Championship> GetChampionshipInscription(int id);
    }
}
