using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class FieldItemRepository : Repository<FieldItem>, IFieldItemRepository
    {

        public FieldItemRepository(AppDbContext context)
: base(context)
        {

        }

        public override IQueryable<FieldItem> GetAll()
        {
            return Db.FieldItens.Include(p => p.Field).OrderBy(p => p.Name).AsQueryable();
        }

        public override FieldItem GetById(int id)
        {
            return Db.FieldItens.Include(p => p.Field).Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
