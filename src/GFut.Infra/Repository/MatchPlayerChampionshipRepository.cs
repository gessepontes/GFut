using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class MatchPlayerChampionshipRepository : Repository<MatchPlayerChampionship>, IMatchPlayerChampionshipRepository
    {

        public MatchPlayerChampionshipRepository(AppDbContext context): base(context)
        {

        }
    }
}
