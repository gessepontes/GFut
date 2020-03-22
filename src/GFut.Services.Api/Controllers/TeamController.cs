using System.Collections.Generic;
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

        // GET: api/Team
        [HttpGet]
        public IEnumerable<TeamViewModel> Get()
        {
            return _teamAppService.GetAll();
        }

        // GET: api/Team/5
        [HttpGet("{id}", Name = "Get")]
        public TeamViewModel Get(int id)
        {
            return _teamAppService.GetById(id);
        }

        [HttpGet("idPerson/{idPerson}", Name = "GetTeamPerson")]
        public IEnumerable<TeamViewModel> GetTeamPerson(int idPerson)
        {
            return _teamAppService.GetTeamPerson(idPerson);
        }

        [HttpGet("idPerson/{idPerson}/{search}", Name = "GetSearchTeamPerson")]
        public IEnumerable<TeamViewModel> GetSearchTeamPerson(int idPerson, string search)
        {
            return _teamAppService.GetSearchTeamPerson(idPerson, search);
        }

        // POST: api/Team
        [HttpPost]
        public void Post([FromBody] TeamViewModel teamViewModel)
        {
            _teamAppService.Add(teamViewModel);
        }

        // PUT: api/Team
        [HttpPut]
        public void Put([FromBody] TeamViewModel teamViewModel)
        {
            _teamAppService.Update(teamViewModel);
        }

        // PUT: api/Team
        [HttpPut("{id}", Name = "PutStatus")]
        public void PutStatus(int id)
        {
            _teamAppService.Status(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _teamAppService.Remove(id);
        }
    }
}
