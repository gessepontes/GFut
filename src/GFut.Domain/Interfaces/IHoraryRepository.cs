using GFut.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface IHoraryRepository : IRepository<Horary> {
        Task<IEnumerable<Horary>> GetHoraryByFieldId(int fieldId);
    }
}
