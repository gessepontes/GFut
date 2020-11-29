using GFut.Domain.Models;
using System.Linq;

namespace GFut.Domain.Interfaces
{
    public interface IHoraryRepository : IRepository<Horary> {
        IQueryable<Horary> GetHoraryByFieldId(int FieldId);
    }
}
