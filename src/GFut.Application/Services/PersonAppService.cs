using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using Microsoft.Extensions.Configuration;
using GFut.Domain.Others;
using System.Linq;
using System.Threading.Tasks;
using static GFut.Domain.Others.Enum;

namespace GFut.Application.Services
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonProfileRepository _personProfileRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public PersonAppService(IMapper mapper, IPersonRepository personRepository, IPersonProfileRepository personProfileRepository, IConfiguration configuration)
        {
            _personRepository = personRepository;
            _personProfileRepository = personProfileRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<PersonViewModel>> GetAll()
        {
            var result = await _personRepository.GetAll();

            result.ToList().ForEach(p => p.Password = "");

            return result.Select(_mapper.Map<PersonViewModel>);
        }

        public async Task<IEnumerable<PersonViewModel>> GetPersonChampionshipDrop()
        {
            var result = await _personRepository.GetPersonChampionshipDrop();
            return result.Select(_mapper.Map<PersonViewModel>); 
        }

        public async Task<IEnumerable<PersonViewModel>> GetPersonFieldDrop()
        {
            var result = await _personRepository.GetPersonFieldDrop();
            return result.Select(_mapper.Map<PersonViewModel>);
        }

        public async Task<IEnumerable<PersonViewModel>> GetPersonAllDrop()
        {
            var result = await _personRepository.GetPersonAllDrop();
            return result.Select(_mapper.Map<PersonViewModel>);
        }

        public async Task<PersonViewModel> GetById(int id)
        {
            return _mapper.Map<PersonViewModel>(await _personRepository.GetById(id));
        }

        public void Register(PersonViewModel personViewModel)
        {
            var config = _configuration.GetValue<string>("Config:AtletaBase64");


            personViewModel.Password = Divers.GenerateMD5(personViewModel.Password);

            if (personViewModel.Picture == "")
            {
                personViewModel.Picture = Divers.Base64ToImage(config, "PERSON");
            }
            else
            {
                personViewModel.Picture = Divers.Base64ToImage(personViewModel.Picture, "PERSON");
            }

            Person _person = _mapper.Map<Person>(personViewModel);
            _personRepository.Add(_person);

            foreach (var item in personViewModel.ProfileType)
            {
                PersonProfile _personProfile = new PersonProfile
                {
                    PersonId = _person.Id,
                    ProfileType = (ProfileType)item
                };

                _personProfileRepository.Add(_personProfile);
            }

            //var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(personViewModel);
            //Bus.SendCommand(registerCommand);
        }

        public void Update(PersonViewModel personViewModel)
        {
            var result = _personProfileRepository.GetAll().Result;

            string[] picture = personViewModel.Picture.Split('/');

            if (picture[0] != "data:image")
            {
                personViewModel.Picture = picture[picture.Count() - 1];
            }
            else
            {
                personViewModel.Picture = Divers.Base64ToImage(personViewModel.Picture, "PERSON");
            }

            if (personViewModel.Password != "")
                personViewModel.Password = Divers.GenerateMD5(personViewModel.Password);


            Person _person = _mapper.Map<Person>(personViewModel);
            _personRepository.Update(_person);

            List<PersonProfile> personProfilesList = result.Where(p => p.PersonId == personViewModel.Id).ToList();
            _personProfileRepository.RemoveRange(personProfilesList);

            foreach (var item in personViewModel.ProfileType)
            {
                PersonProfile _personProfile = new PersonProfile
                {
                    PersonId = _person.Id,
                    ProfileType = (ProfileType)item
                };

                _personProfileRepository.Add(_personProfile);
            }

            //var updateCommand = _mapper.Map<UpdateCustomerCommand>(personViewModel);
            //Bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
            Person _person = _personRepository.GetById(id).Result;
            var result = _personProfileRepository.GetAll().Result;

            List<PersonProfile> personProfilesList = result.Where(p => p.PersonId == _person.Id).ToList();
            _personProfileRepository.RemoveRange(personProfilesList);

            _personRepository.Remove(id);

            //var removeCommand = new RemoveCustomerCommand(id);
            //Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
