using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class PersonProfileRepository : Repository<PersonProfile>, IPersonProfileRepository
    {

        public PersonProfileRepository(AppDbContext context)
  : base(context)
        {

        } 
    }
}
