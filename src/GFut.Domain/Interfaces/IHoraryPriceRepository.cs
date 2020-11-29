using GFut.Domain.Models;
using System.Linq;

namespace GFut.Domain.Interfaces
{
    public interface IHoraryPriceRepository : IRepository<HoraryPrice> {
        IQueryable<HoraryPrice> GetHoraryPriceByFieldId(int FieldId);
    }
}
