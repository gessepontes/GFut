using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace GFut.Infra.Data.Repository
{
    public class HoraryExtraRepository : Repository<HoraryExtra>, IHoraryExtraRepository
    {

        public HoraryExtraRepository(AppDbContext context)
: base(context)
        {

        }

        public override async Task<IEnumerable<HoraryExtra>> GetAll()
        {
            return await Db.HoraryExtras.Include(p => p.FieldItem).OrderBy(p => p.FieldItem.Name).ToListAsync();
        }

        public async Task<IEnumerable<HoraryExtra>> GetHoraryExtraByFieldId(int FieldId)
        {
            return await Db.HoraryExtras.Include(p => p.FieldItem).Where(p => p.FieldItem.FieldId == FieldId).ToListAsync();
        }
    }
}
