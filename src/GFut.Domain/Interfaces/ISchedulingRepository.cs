using GFut.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface ISchedulingRepository : IRepository<Scheduling> {
         Task<IEnumerable<Scheduling>> GetSchedulingByFieldId(int FieldId);
    }
}
