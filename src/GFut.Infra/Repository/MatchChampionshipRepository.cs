using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class MatchChampionshipRepository : Repository<MatchChampionship>, IMatchChampionshipRepository
    {

        public MatchChampionshipRepository(AppDbContext context)
: base(context)
        {

        }

        public override IQueryable<MatchChampionship> GetAll()
        {
            return Db.MatchChampionships.Include(p => p.FieldItem).Include(p => p.HomeSubscription).Include(p => p.GuestSubscription).OrderBy(p => p.MatchDate).AsQueryable();
        }

        public override MatchChampionship GetById(int id)
        {
            return Db.MatchChampionships.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
