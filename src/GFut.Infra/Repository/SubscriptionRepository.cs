using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GFut.Infra.Data.Repository
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {

        public SubscriptionRepository(AppDbContext context)
: base(context)
        {

        }

        public override async Task<IEnumerable<Subscription>> GetAll()
        {
            return await Db.Subscriptions.Include(p => p.Championship).Include(p => p.Team).OrderBy(p => p.Championship.Name).ToListAsync();
        }
    }
}
