using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class GroupChampionshipRepository : Repository<GroupChampionship>, IGroupChampionshipRepository
    {

        public GroupChampionshipRepository(AppDbContext context)
: base(context)
        {

        }

        public override IQueryable<GroupChampionship> GetAll()
        {
            return Db.GroupChampionships.Include(p => p.Subscription).ThenInclude(p => p.Team).OrderBy(p => p.GroupId).AsQueryable();
        }

        public override GroupChampionship GetById(int id)
        {
            return Db.GroupChampionships.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
