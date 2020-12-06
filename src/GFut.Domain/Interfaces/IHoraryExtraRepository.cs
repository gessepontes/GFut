using GFut.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface IHoraryExtraRepository : IRepository<HoraryExtra>
    {
        Task<IEnumerable<HoraryExtra>> GetHoraryExtraByFieldId(int FieldId);

    }
}
