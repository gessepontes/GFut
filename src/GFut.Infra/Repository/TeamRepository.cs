using System.Collections.Generic;
using System.Linq;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using GFut.Infra.Data.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GFut.Infra.Data.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(AppDbContext context)
          : base(context)
        {

        }

        public async Task<IEnumerable<Team>> GetTeamPerson(int id)
        {
            return await Db.Teams.Where(p => p.PersonId == id && p.State == true).OrderBy(p => p.Name).ToListAsync();
        }

        public override async Task<IEnumerable<Team>> GetAll()
        {
            return await Db.Teams.Where(p => p.State == true).OrderBy(p => p.Name).ToListAsync();
        }
    }
}
