using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;
using GFut.Domain.Others;
using System.Threading.Tasks;

namespace GFut.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPersonProfileRepository _personProfileRepository;
        private readonly IMapper _mapper;

        public UserAppService(IMapper mapper, IUserRepository userRepository, 
            IPersonRepository personRepository, IPersonProfileRepository personProfileRepository)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
            _personProfileRepository = personProfileRepository;
            _mapper = mapper;
        }

        public async Task<PersonViewModel> SignIn(UserViewModel userViewModel)
        {
            userViewModel.Password = Divers.GenerateMD5(userViewModel.Password);

            Person person = await _userRepository.SignIn(_mapper.Map<User>(userViewModel));
            PersonViewModel personViewModel = _mapper.Map<PersonViewModel>(person);

            personViewModel.Team = _mapper.Map<TeamViewModel>(person.Teams.Where(p => p.Active == true && p.State == true).FirstOrDefault());
            return personViewModel;
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
                ProfileType = Domain.Others.Enum.ProfileType.Jogador
            };

            _personProfileRepository.Add(personProfile);
        }

        public void UpdateUser(UserViewModel userViewModel)
        {
            _userRepository.UpdateUser(_mapper.Map<User>(userViewModel));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
