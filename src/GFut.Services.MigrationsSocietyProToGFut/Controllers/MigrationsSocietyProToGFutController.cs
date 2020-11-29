using GFut.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.MigrationsSocietyProToGFut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationsSocietyProToGFutController : ControllerBase
    {
        private readonly IMigrationsSocietyProToGFutAppService _migrationsSocietyProToGFut;

        public MigrationsSocietyProToGFutController(IMigrationsSocietyProToGFutAppService migrationsSocietyProToGFut)
        {
            _migrationsSocietyProToGFut = migrationsSocietyProToGFut;
        }

        [HttpGet("GetPessoa/")]
        public void GetPessoa()
        {
            _migrationsSocietyProToGFut.GetPessoa();
        }
    }
}
