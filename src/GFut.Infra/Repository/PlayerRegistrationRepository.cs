using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Infra.Data.Repository
{
    public class PlayerRegistrationRepository : Repository<PlayerRegistration>, IPlayerRegistrationRepository
    {

        public PlayerRegistrationRepository(AppDbContext context)
: base(context)
        {

        }

        public override async Task<IEnumerable<PlayerRegistration>> GetAll()
        {
            return await Db.PlayerRegistrations.Include(p => p.Subscription).Include(p => p.Player).OrderBy(p => p.Player.Name).ToListAsync();
        }
    }
}
