using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GFut.Infra.Data.Repository
{
    public class SchedulingRepository : Repository<Scheduling>, ISchedulingRepository
    {

        public SchedulingRepository(AppDbContext context)
: base(context)
        {

        }

        public override async Task<IEnumerable<Scheduling>> GetAll()
        {
            return await Db.Schedulings.Include(p => p.Person)
                .Include(p => p.Horary).ThenInclude(p => p.FieldItem)
                .Include(p => p.HoraryExtra).ThenInclude(p => p.FieldItem)
                .OrderBy(p => p.Person.Name).ToListAsync();
        }

        public override async Task<Scheduling> GetById(int id)
        {
            return await Db.Schedulings.Include(p => p.Person)
                .Include(p => p.Horary).ThenInclude(p => p.FieldItem)
                .Include(p => p.HoraryExtra).ThenInclude(p => p.FieldItem).FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public async Task<IEnumerable<Scheduling>> GetSchedulingByFieldId(int FieldId)
        {
            return await Db.Schedulings
                .Include(p => p.Person)
                .Include(p => p.Horary).ThenInclude(p => p.FieldItem)
                .Include(p => p.HoraryExtra).ThenInclude(p => p.FieldItem)
                .Where(p => p.Horary.FieldItem.FieldId == FieldId || p.HoraryExtra.FieldItem.FieldId == FieldId)
                .OrderBy(p => p.Person.Name).ToListAsync();
        }
    }
}
