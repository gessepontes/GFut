using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class SchedulingRepository : Repository<Scheduling>, ISchedulingRepository
    {

        public SchedulingRepository(AppDbContext context)
: base(context)
        {

        }

        public override IQueryable<Scheduling> GetAll()
        {
            return Db.Schedulings.Include(p => p.Person)
                .Include(p => p.Horary).ThenInclude(p => p.FieldItem)
                .Include(p => p.HoraryExtra).ThenInclude(p => p.FieldItem)
                .OrderBy(p => p.Person.Name);
        }

        public IQueryable<Scheduling> GetSchedulingByFieldId(int FieldId)
        {
            return Db.Schedulings
                .Include(p => p.Horary).ThenInclude(p => p.FieldItem)
                .Include(p => p.HoraryExtra).ThenInclude(p => p.FieldItem)
                .Where(p => p.Horary.FieldItem.FieldId == FieldId || p.HoraryExtra.FieldItem.FieldId == FieldId)
                .OrderBy(p => p.Person.Name);
        }
    }
}
