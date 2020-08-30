using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class HoraryPriceRepository : Repository<HoraryPrice>, IHoraryPriceRepository
    {

        public HoraryPriceRepository(AppDbContext context)
: base(context)
        {

        }

        public override IQueryable<HoraryPrice> GetAll()
        {
            return Db.HoraryPrices.Include(p => p.FieldItem).OrderBy(p => p.FieldItem.Name).AsQueryable();
        }

        public override HoraryPrice GetById(int id)
        {
            return Db.HoraryPrices.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
