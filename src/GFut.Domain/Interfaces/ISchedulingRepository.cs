using GFut.Domain.Models;
using System.Linq;

namespace GFut.Domain.Interfaces
{
    public interface ISchedulingRepository : IRepository<Scheduling> {
        IQueryable<Scheduling> GetSchedulingByFieldId(int FieldId);
    }
}
