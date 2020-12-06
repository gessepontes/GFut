using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GFut.Infra.Data.Repository
{
    public class GroupChampionshipRepository : Repository<GroupChampionship>, IGroupChampionshipRepository
    {

        public GroupChampionshipRepository(AppDbContext context)
: base(context)
        {

        }

        public override async Task<IEnumerable<GroupChampionship>> GetAll()
        {
            return await Db.GroupChampionships.Include(p => p.Subscription).ThenInclude(p => p.Team).OrderBy(p => p.GroupId).ToListAsync();
        }
    }
}
