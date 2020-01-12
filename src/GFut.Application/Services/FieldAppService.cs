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
    public class FieldAppService : IFieldAppService
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IMapper _mapper;

        public FieldAppService(IMapper mapper, IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
            _mapper = mapper;
        }

        public IEnumerable<FieldViewModel> GetAll()
        {
            return _fieldRepository.GetAll().ProjectTo<FieldViewModel>(_mapper.ConfigurationProvider);
        }

        public FieldViewModel GetById(int id)
        {
            return _mapper.Map<FieldViewModel>(_fieldRepository.GetById(id));
        }

        public void Update(FieldViewModel fieldViewModel)
        {
            _fieldRepository.Update(_mapper.Map<Field>(fieldViewModel));

            //var updateCommand = _mapper.Map<UpdateCustomerCommand>(fieldViewModel);
            //Bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
            _fieldRepository.Remove(id);

            //var removeCommand = new RemoveCustomerCommand(id);
            //Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
