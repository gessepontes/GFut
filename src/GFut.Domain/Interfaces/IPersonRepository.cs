using GFut.Domain.Models;

namespace GFut.Domain.Interfaces
{
    public interface IPersonRepository : IRepository<Person> {

        Person Authenticate(string email,string password);
    }
}
