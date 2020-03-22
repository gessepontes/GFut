using GFut.Domain.Models;

namespace GFut.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User> {
        Person SignIn(User user);
        void UpdateUser(User user);
    }
}
