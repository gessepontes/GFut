using GFut.Domain.Models;

namespace GFut.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User> {

        void SignUp(User user);
        Person SignIn(User user);

    }
}
