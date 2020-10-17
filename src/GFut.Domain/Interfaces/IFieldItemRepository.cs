using GFut.Domain.Models;
using System.Linq;

namespace GFut.Domain.Interfaces
{
    public interface IFieldItemRepository : IRepository<FieldItem> {
        IQueryable<FieldItem> GetFieldItemByFieldId(int FieldId);
    }
}
