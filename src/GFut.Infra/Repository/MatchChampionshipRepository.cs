using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Infra.Data.Repository
{
    public class MatchChampionshipRepository : Repository<MatchChampionship>, IMatchChampionshipRepository
    {

        public MatchChampionshipRepository(AppDbContext context)
: base(context)
        {

        }

        public override async Task<IEnumerable<MatchChampionship>> GetAll()
        {
            return await Db.MatchChampionships.Include(p => p.FieldItem).Include(p => p.HomeSubscription).Include(p => p.GuestSubscription).OrderBy(p => p.MatchDate).ToListAsync();
        }
    }
}
