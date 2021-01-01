using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;
using GFut.Domain.Others;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GFut.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonProfileRepository _personProfileRepository;
        private readonly IPersonAppService _personAppService;
        private readonly IMapper _mapper;

        public UserAppService(IMapper mapper,
            IPersonRepository personRepository,
            IPersonProfileRepository personProfileRepository,
            IPersonAppService personAppService)
        {
            _personRepository = personRepository;
            _personProfileRepository = personProfileRepository;
            _personAppService = personAppService;
            _mapper = mapper;
        }

        public async Task<PersonViewModel> SignIn(UserViewModel userViewModel)
        {
            userViewModel.Password = Divers.GenerateMD5(userViewModel.Password);

            Person person = await _personRepository.SignIn(_mapper.Map<User>(userViewModel));

            return await _personAppService.GetProfileTeam(person);
        }

        public void SignUp(UserViewModel userViewModel)
        {
            Person person = new Person
            {
                Name = userViewModel.Name,
                Email = userViewModel.Email,
                Password = userViewModel.Password,
                Phone = userViewModel.Phone,
                Picture = userViewModel.Picture,
                Confirmation = true,
            };

            _personRepository.Add(person);

            PersonProfile personProfile = new PersonProfile
            {
                PersonId = person.Id,
                ProfileType = Domain.Others.Enum.ProfileType.Usuario
            };

            _personProfileRepository.Add(personProfile);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
