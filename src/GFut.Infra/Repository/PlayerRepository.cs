
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using GFut.Infra.Data.Context;
using System.Threading.Tasks;

namespace GFut.Infra.Data.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(AppDbContext context)
: base(context)
        {

        }

        public async Task<IEnumerable<Player>> GetPlayerTeam(int id)
        {
            return await Db.Players.Where(p => p.TeamId == id && p.Active == true).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<Player>> GetPlayerTeamByIdSubscription(int id)
        {
            var _teamId = Db.Subscriptions.FindAsync(id).Result.TeamId;

            var listPlayer = await (from p in Db.Players
                                    where p.TeamId == _teamId && p.Dispensed == false
                                    && !(from pr in Db.PlayerRegistrations
                                         select pr.PlayerId).Contains(p.Id)
                                    select new Player
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                    }).ToListAsync();

            return listPlayer;
        }
    }
}