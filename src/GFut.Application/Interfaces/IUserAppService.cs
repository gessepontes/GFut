using GFut.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GFut.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        void SignUp(UserViewModel userViewModel);
        PersonViewModel SignIn(UserViewModel userViewModel);
        void UpdateUser(UserViewModel userViewModel);
    }
}
