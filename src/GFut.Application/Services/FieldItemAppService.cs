using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;
using GFut.Domain.Others;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GFut.Application.Services
{
    public class FieldItemAppService : IFieldItemAppService
    {
        private readonly IFieldItemRepository _fieldItemRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public FieldItemAppService(IMapper mapper, IFieldItemRepository fieldRepository, IConfiguration configuration)
        {
            _fieldItemRepository = fieldRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<FieldItemViewModel>> GetAll()
        {
            var result = await _fieldItemRepository.GetAll();
            return result.Select(_mapper.Map<FieldItemViewModel>);
        }

        public async Task<FieldItemViewModel> GetById(int id)
        {
            return _mapper.Map<FieldItemViewModel>(await _fieldItemRepository.GetById(id));
        }

        public void Update(FieldItemViewModel fieldViewModel)
        {
            string[] symbol = fieldViewModel.Picture.Split('/');

            if (symbol[0] != "data:image")
            {
                fieldViewModel.Picture = symbol[symbol.Count() - 1];
            }
            else
            {
                fieldViewModel.Picture = Divers.Base64ToImage(fieldViewModel.Picture, "FIELDITEM");
            }

            _fieldItemRepository.Update(_mapper.Map<FieldItem>(fieldViewModel));
        }

        public void Remove(int id)
        {
            _fieldItemRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(FieldItemViewModel fieldViewModel)
        {
            var config = _configuration.GetValue<string>("Config:AtletaBase64");

            if (fieldViewModel.Picture == "")
            {
                fieldViewModel.Picture = Divers.Base64ToImage(config, "FIELDITEM");
            }
            else
            {
                fieldViewModel.Picture = Divers.Base64ToImage(fieldViewModel.Picture, "FIELDITEM");
            }

            _fieldItemRepository.Add(_mapper.Map<FieldItem>(fieldViewModel));
        }

        public async Task<IEnumerable<FieldItemViewModel>> GetFieldItemByFieldId(int FieldId)
        {
            var result = await _fieldItemRepository.GetFieldItemByFieldId(FieldId);
            return result.Select(_mapper.Map<FieldItemViewModel>);
        }
    }
}
