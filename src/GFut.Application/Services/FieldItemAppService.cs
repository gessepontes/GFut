using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;
using GFut.Domain.Others;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace GFut.Application.Services
{
    public class FieldItemAppService : IFieldItemAppService
    {
        private readonly IFieldItemRepository _fieldItemRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public FieldItemAppService(IMapper mapper, IFieldItemRepository fieldRepository, IHostingEnvironment env)
        {
            _fieldItemRepository = fieldRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<FieldItemViewModel> GetAll()
        {
            return _fieldItemRepository.GetAll().ProjectTo<FieldItemViewModel>(_mapper.ConfigurationProvider);
        }

        public FieldItemViewModel GetById(int id)
        {
            return _mapper.Map<FieldItemViewModel>(_fieldItemRepository.GetById(id));
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
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();


            if (fieldViewModel.Picture == "")
            {
                fieldViewModel.Picture = Divers.Base64ToImage(config.GetSection(key: "Config")["AtletaBase64"], "FIELDITEM");
            }
            else
            {
                fieldViewModel.Picture = Divers.Base64ToImage(fieldViewModel.Picture, "FIELDITEM");
            }

            _fieldItemRepository.Add(_mapper.Map<FieldItem>(fieldViewModel));
        }

        public IEnumerable<FieldItemViewModel> GetSearchFieldItem(string search)
        {
            return _mapper.Map<IEnumerable<FieldItemViewModel>>(_fieldItemRepository.GetAll().Where(p => p.Name.Contains(search)));
        }
    }
}
