using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class HoraryExtraRepository : Repository<HoraryExtra>, IHoraryExtraRepository
    {

        public HoraryExtraRepository(AppDbContext context)
: base(context)
        {

        }

        public override IQueryable<HoraryExtra> GetAll()
        {
            return Db.HoraryExtras.Include(p => p.FieldItem).OrderBy(p => p.FieldItem.Name).AsQueryable();
        }

        public override HoraryExtra GetById(int id)
        {
            return Db.HoraryExtras.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
