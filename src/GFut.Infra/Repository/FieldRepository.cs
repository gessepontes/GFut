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
    public class FieldRepository : Repository<Field>, IFieldRepository
    {

        public FieldRepository(AppDbContext context)
: base(context)
        {

        }

        public override async Task<IEnumerable<Field>> GetAll()
        {
            return await Db.Fields.OrderBy(p => p.Name).ToListAsync();
        }
    }
}
