using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Infra.Data.Repository
{
    public class HoraryPriceRepository : Repository<HoraryPrice>, IHoraryPriceRepository
    {

        public HoraryPriceRepository(AppDbContext context)
: base(context)
        {

        }

        public override async Task<IEnumerable<HoraryPrice>> GetAll()
        {
            return await Db.HoraryPrices.Include(p => p.FieldItem).OrderBy(p => p.FieldItem.Name).ToListAsync();
        }

        public async Task<IEnumerable<HoraryPrice>> GetHoraryPriceByFieldId(int FieldId)
        {
            return await Db.HoraryPrices.Include(p => p.FieldItem).Where(p => p.FieldItem.FieldId == FieldId).ToListAsync();
        }
    }
}
