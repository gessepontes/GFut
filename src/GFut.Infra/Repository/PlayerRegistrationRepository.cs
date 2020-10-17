using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class PlayerRegistrationRepository : Repository<PlayerRegistration>, IPlayerRegistrationRepository
    {

        public PlayerRegistrationRepository(AppDbContext context)
: base(context)
        {

        }

        public override IQueryable<PlayerRegistration> GetAll()
        {
            return Db.PlayerRegistrations.Include(p => p.Subscription).Include(p => p.Player).OrderBy(p => p.Player.Name).AsQueryable();
        }

        public override PlayerRegistration GetById(int id)
        {
            return Db.PlayerRegistrations.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
