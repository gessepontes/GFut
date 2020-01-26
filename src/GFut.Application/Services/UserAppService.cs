using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;

namespace GFut.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserAppService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public PersonViewModel SignIn(UserViewModel userViewModel)
        {
            return _mapper.Map<PersonViewModel>(_userRepository.SignIn(_mapper.Map<User>(userViewModel)));
        }

        public void SignUp(UserViewModel userViewModel)
        {
            _userRepository.SignUp(_mapper.Map<User>(userViewModel));
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
