using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GFut.Infra.Data.Repository
{
    public class HoraryRepository : Repository<Horary>, IHoraryRepository
    {

        public HoraryRepository(AppDbContext context)
: base(context)
        {

        }

        public override async Task<IEnumerable<Horary>> GetAll()
        {
            return await Db.Horarys.Include(p => p.FieldItem).OrderBy(p => p.FieldItem.Name).ToListAsync();
        }

        public async Task<IEnumerable<Horary>> GetAllHorary()
        {
            var _data = await Db.Horarys.Include(p => p.FieldItem).OrderBy(p => p.FieldItem.Name).ToListAsync();
            return _data;
        }

        public async Task<IEnumerable<Horary>> GetHoraryByFieldId(int fieldId)
        {
            var _data = await Db.Horarys.Include(p => p.FieldItem).Where(p => p.FieldItem.FieldId == fieldId).ToListAsync();
            return _data;
        }
    }
}
