using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class FieldRepository : Repository<Field>, IFieldRepository
    {

        public FieldRepository(AppDbContext context)
: base(context)
        {

        }

        public override IQueryable<Field> GetAll()
        {
            return Db.Fields.OrderBy(p => p.Name).AsQueryable();
        }

        public override Field GetById(int id)
        {
            return Db.Fields.Include(p => p.FieldItens).Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
