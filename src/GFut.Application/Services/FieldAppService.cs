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
    public class FieldAppService : IFieldAppService
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public FieldAppService(IMapper mapper, IFieldRepository fieldRepository, IConfiguration configuration)
        {
            _fieldRepository = fieldRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<FieldViewModel>> GetAll()
        {
            var result = await _fieldRepository.GetAll();
            return result.Select(_mapper.Map<FieldViewModel>);
        }

        public async Task<FieldViewModel> GetById(int id)
        {
            return _mapper.Map<FieldViewModel>(await _fieldRepository.GetById(id));
        }

        public void Update(FieldViewModel fieldViewModel)
        {
            string[] symbol = fieldViewModel.Picture.Split('/');

            if (symbol[0] != "data:image")
            {
                fieldViewModel.Picture = symbol[symbol.Count() - 1];
            }
            else
            {
                fieldViewModel.Picture = Divers.Base64ToImage(fieldViewModel.Picture, "FIELD");
            }

            _fieldRepository.Update(_mapper.Map<Field>(fieldViewModel));
        }

        public void Remove(int id)
        {
            _fieldRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(FieldViewModel fieldViewModel)
        {
            var config = _configuration.GetValue<string>("Config:AtletaBase64");

            if (fieldViewModel.Picture == "")
            {
                fieldViewModel.Picture = Divers.Base64ToImage(config, "FIELD");
            }
            else
            {
                fieldViewModel.Picture = Divers.Base64ToImage(fieldViewModel.Picture, "FIELD");
            }

            _fieldRepository.Add(_mapper.Map<Field>(fieldViewModel));
        }
    }
}
