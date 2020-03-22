
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
    }
}