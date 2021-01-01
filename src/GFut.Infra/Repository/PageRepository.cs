using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class PageRepository : Repository<Page>, IPageRepository
    {

        public PageRepository(AppDbContext context)
  : base(context)
        {

        }
    }
}
