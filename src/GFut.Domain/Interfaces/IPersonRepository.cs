using GFut.Domain.Models;
using System.Linq;

namespace GFut.Domain.Interfaces
{
    public interface IPersonRepository : IRepository<Person> {

        Person Authenticate(string email,string password);
        IQueryable<Person> GetPersonCampeonato();
    }
}
