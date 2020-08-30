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
    public class FieldAppService : IFieldAppService
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public FieldAppService(IMapper mapper, IFieldRepository fieldRepository, IHostingEnvironment env)
        {
            _fieldRepository = fieldRepository;
            _mapper = mapper;
            _env = env;
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
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();


            if (fieldViewModel.Picture == "")
            {
                fieldViewModel.Picture = Divers.Base64ToImage(config.GetSection(key: "Config")["AtletaBase64"], "FIELD");
            }
            else
            {
                fieldViewModel.Picture = Divers.Base64ToImage(fieldViewModel.Picture, "FIELD");
            }

            _fieldRepository.Add(_mapper.Map<Field>(fieldViewModel));
        }

        public IEnumerable<FieldViewModel> GetSearchField(string search)
        {
            return _mapper.Map<IEnumerable<FieldViewModel>>(_fieldRepository.GetAll().Where(p => p.Name.Contains(search)));
        }
    }
}
