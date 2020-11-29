using GFut.Domain.Models;
using System.Linq;

namespace GFut.Domain.Interfaces
{
    public interface IHoraryExtraRepository : IRepository<HoraryExtra> {
        IQueryable<HoraryExtra> GetHoraryExtraByFieldId(int FieldId);

    }
}
