using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using GFut.Domain.Others;
using System.Linq;

namespace GFut.Application.Services
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonProfileRepository _personProfileRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;


        public PersonAppService(IMapper mapper, IPersonRepository personRepository, IPersonProfileRepository personProfileRepository, IHostingEnvironment env)
        {
            _personRepository = personRepository;
            _personProfileRepository = personProfileRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            return _personRepository.GetAll().ProjectTo<PersonViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<PersonViewModel> GetPersonChampionshipDrop()
        {
            return _personRepository.GetPersonChampionshipDrop().ProjectTo<PersonViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<PersonViewModel> GetPersonFieldDrop()
        {
            return _personRepository.GetPersonFieldDrop().ProjectTo<PersonViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<PersonViewModel> GetPersonAllDrop()
        {
            return _personRepository.GetPersonAllDrop().ProjectTo<PersonViewModel>(_mapper.ConfigurationProvider);
        }

        public PersonViewModel GetById(int id)
        {
            return _mapper.Map<PersonViewModel>(_personRepository.GetById(id));
        }

        public void Register(PersonViewModel personViewModel)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();


            if (personViewModel.Picture == "")
            {
                personViewModel.Picture = Divers.Base64ToImage(config.GetSection(key: "Config")["AtletaBase64"], "PERSON");
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
                    ProfileType = item
                };

                _personProfileRepository.Add(_personProfile);
            }

            //var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(personViewModel);
            //Bus.SendCommand(registerCommand);
        }

        public void Update(PersonViewModel personViewModel)
        {
            string[] picture = personViewModel.Picture.Split('/');

            if (picture[0] != "data:image")
            {
                personViewModel.Picture = picture[picture.Count() - 1];
            }
            else
            {
                personViewModel.Picture = Divers.Base64ToImage(personViewModel.Picture, "PERSON");
            }

            Person _person = _mapper.Map<Person>(personViewModel);
            _personRepository.Update(_person);

            List<PersonProfile> personProfilesList = _personProfileRepository.GetAll().Where(p => p.PersonId == personViewModel.Id).ToList();
            _personProfileRepository.RemoveRange(personProfilesList);

            foreach (var item in personViewModel.ProfileType)
            {
                PersonProfile _personProfile = new PersonProfile
                {
                    PersonId = _person.Id,
                    ProfileType = item
                };

                _personProfileRepository.Add(_personProfile);
            }

            //var updateCommand = _mapper.Map<UpdateCustomerCommand>(personViewModel);
            //Bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
            Person _person = _personRepository.GetById(id);

            List<PersonProfile> personProfilesList = _personProfileRepository.GetAll().Where(p => p.PersonId == _person.Id).ToList();
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
