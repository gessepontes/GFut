using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using GFut.Infra.Data.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GFut.Infra.Data.Repository
{
    public class PageProfileRepository : Repository<PageProfile>, IPageProfileRepository
    {

        public PageProfileRepository(AppDbContext context)
  : base(context)
        {

        }

        public async Task<IEnumerable<PageProfile>> GetPageProfileByProfileId(int profileId)
        {
            var _data = await Db.PageProfiles.Include(x => x.Page).ThenInclude(p => p.Pages).Where(p => p.ProfileId == profileId && p.Page.ParentId == null).ToListAsync();
            return _data;
        }
    }
}
