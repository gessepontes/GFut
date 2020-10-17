
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(AppDbContext context)
: base(context)
        {

        }

        public IEnumerable<Player> GetPlayerTeam(int id)
        {
            return Db.Players.Where(p => p.TeamId == id && p.Active == true).OrderBy(p=>p.Name).ToList();
        }

        public IEnumerable<Player> GetPlayerTeamByIdSubscription(int id)
        {
            var _teamId = Db.Subscriptions.Find(id).TeamId;

            var listPlayer = from p in Db.Players
                             where p.TeamId == _teamId && p.Dispensed == false 
                             && !(from pr in Db.PlayerRegistrations 
                                  select pr.PlayerId).Contains(p.Id)
                             select new Player
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                             };

            return listPlayer;
        }
    }
}