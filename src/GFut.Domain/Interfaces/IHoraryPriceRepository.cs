using GFut.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface IHoraryPriceRepository : IRepository<HoraryPrice> {
         Task<IEnumerable<HoraryPrice>> GetHoraryPriceByFieldId(int FieldId);
    }
}
