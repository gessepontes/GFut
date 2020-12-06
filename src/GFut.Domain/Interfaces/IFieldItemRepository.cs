using GFut.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface IFieldItemRepository : IRepository<FieldItem> {
         Task<IEnumerable<FieldItem>> GetFieldItemByFieldId(int FieldId);
    }
}
