using GFut.Domain.Models;
using System.Threading.Tasks;

namespace GFut.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User> {
        Task<Person> SignIn(User user);
        void UpdateUser(User user);
    }
}
