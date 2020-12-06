using System.Collections.Generic;
using System.Threading.Tasks;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamAppService _teamAppService;

        public TeamController(ITeamAppService teamAppService)
        {
            _teamAppService = teamAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<TeamViewModel>> Get()
        {
            return await _teamAppService.GetAll();
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<TeamViewModel> Get(int id)
        {
            return await _teamAppService.GetById(id);
        }

        [HttpGet("idPerson/{idPerson}", Name = "GetTeamPerson")]
        public async Task<IEnumerable<TeamViewModel>> GetTeamPerson(int idPerson)
        {
            return await _teamAppService.GetTeamPerson(idPerson);
        }

        [HttpPost]
        public void Post([FromBody] TeamViewModel teamViewModel)
        {
            _teamAppService.Add(teamViewModel);
        }

        [HttpPut]
        public void Put([FromBody] TeamViewModel teamViewModel)
        {
            _teamAppService.Update(teamViewModel);
        }

        [HttpPut("{id}", Name = "PutStatus")]
        public void PutStatus(int id)
        {
            _teamAppService.Status(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _teamAppService.Remove(id);
        }
    }
}
