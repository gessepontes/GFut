using GFut.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace GFut.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        void SignUp(UserViewModel userViewModel);
        Task<PersonViewModel> SignIn(UserViewModel userViewModel);
        void UpdateUser(UserViewModel userViewModel);
    }
}
