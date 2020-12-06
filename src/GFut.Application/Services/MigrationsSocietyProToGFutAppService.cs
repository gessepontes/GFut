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
        private readonly IMapper _mapper;

        public MigrationsSocietyProToGFutAppService(
            IMapper mapper,
            IMigrationsSocietyProToGFutRepository migrationsSocietyProToGFutRepository)
        {
            _migrationsSocietyProToGFutRepository = migrationsSocietyProToGFutRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public void GetPessoa()
        {
            _migrationsSocietyProToGFutRepository.GetPessoa();
        }
    }
}
