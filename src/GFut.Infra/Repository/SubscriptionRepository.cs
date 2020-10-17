using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {

        public SubscriptionRepository(AppDbContext context)
: base(context)
        {

        }

        public override IQueryable<Subscription> GetAll()
        {
            return Db.Subscriptions.Include(p => p.Championship).Include(p => p.Team).OrderBy(p => p.Championship.Name).AsQueryable();
        }

        public override Subscription GetById(int id)
        {
            return Db.Subscriptions.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
