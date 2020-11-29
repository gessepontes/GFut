using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace GFut.Application.Services
{
    public class MigrationsSocietyProToGFutAppService : IMigrationsSocietyProToGFutAppService
    {
        private readonly IMigrationsSocietyProToGFutRepository  _migrationsSocietyProToGFutRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public MigrationsSocietyProToGFutAppService(
            IMapper mapper,
            IMigrationsSocietyProToGFutRepository migrationsSocietyProToGFutRepository,
            IHostingEnvironment env)
        {
            _migrationsSocietyProToGFutRepository = migrationsSocietyProToGFutRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void GetCampeonato()
        {
            throw new NotImplementedException();
        }

        public void GetCampo()
        {
            throw new NotImplementedException();
        }

        public void GetJogador()
        {
            throw new NotImplementedException();
        }

        public void GetPessoa()
        {
            _migrationsSocietyProToGFutRepository.GetPessoa();
        }

        public void GetTime()
        {
            throw new NotImplementedException();
        }
    }
}
