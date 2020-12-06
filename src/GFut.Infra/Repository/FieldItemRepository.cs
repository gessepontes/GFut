using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GFut.Infra.Data.Repository
{
    public class FieldItemRepository : Repository<FieldItem>, IFieldItemRepository
    {

        public FieldItemRepository(AppDbContext context)
: base(context)
        {

        }

        public override async Task<IEnumerable<FieldItem>> GetAll()
        {
            return await Db.FieldItens.Include(p => p.Field).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<FieldItem>> GetFieldItemByFieldId(int FieldId)
        {
            return await Db.FieldItens.Include(p => p.Field).Where(p => p.FieldId == FieldId).ToListAsync() ;
        }

        public async Task<IEnumerable<FieldItem>> GetFieldItemByFieldIDrop(int FieldId)
        {
            var listFieldItem = (from p in Db.FieldItens where p.FieldId == FieldId
                                select new FieldItem { Id = p.Id, Name = p.Name }).ToListAsync();

            return await listFieldItem;
        }
    }
}
