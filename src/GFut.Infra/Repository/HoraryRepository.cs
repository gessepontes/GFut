using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class HoraryRepository : Repository<Horary>, IHoraryRepository
    {

        public HoraryRepository(AppDbContext context)
: base(context)
        {

        }

        public override IQueryable<Horary> GetAll()
        {
            return Db.Horarys.Include(p => p.FieldItem).OrderBy(p => p.FieldItem.Name).AsQueryable();
        }

        public override Horary GetById(int id)
        {
            return Db.Horarys.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
