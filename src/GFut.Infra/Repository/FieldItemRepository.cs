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
            return Db.FieldItens.Include(p => p.Field).OrderBy(p => p.Name);
        }

        public override FieldItem GetById(int id)
        {
            return Db.FieldItens.Include(p => p.Field).Where(p => p.Id == id).FirstOrDefault();
        }

        public IQueryable<FieldItem> GetFieldItemByFieldId(int FieldId)
        {
            return Db.FieldItens.Include(p => p.Field).Where(p => p.FieldId == FieldId) ;
        }

        public IQueryable<FieldItem> GetFieldItemByFieldIDrop(int FieldId)
        {
            var listFieldItem = from p in Db.FieldItens where p.FieldId == FieldId
                                select new FieldItem { Id = p.Id, Name = p.Name };

            return listFieldItem;
        }
    }
}
