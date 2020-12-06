using GFut.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> Authenticate(string email, string password);
        Task<IEnumerable<Person>> GetPersonChampionshipDrop();
        Task<IEnumerable<Person>> GetPersonAllDrop();
        Task<IEnumerable<Person>> GetPersonFieldDrop();
    }
}
