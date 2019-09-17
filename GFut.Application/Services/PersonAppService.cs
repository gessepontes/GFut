using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;

namespace GFut.Application.Services
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonAppService(IMapper mapper, IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            return _personRepository.GetAll().ProjectTo<PersonViewModel>(_mapper.ConfigurationProvider);
        }

        public PersonViewModel GetById(int id)
        {
            return _mapper.Map<PersonViewModel>(_personRepository.GetById(id));
        }

        public void Register(PersonViewModel personViewModel)
        {
            _personRepository.Add(_mapper.Map<Person>(personViewModel));
            //var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(personViewModel);
            //Bus.SendCommand(registerCommand);
        }

        public void Update(PersonViewModel personViewModel)
        {
            _personRepository.Update(_mapper.Map<Person>(personViewModel));

            //var updateCommand = _mapper.Map<UpdateCustomerCommand>(personViewModel);
            //Bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
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
