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

        // POST: api/Team
        [HttpPost]
        public void Post([FromBody] TeamViewModel teamViewModel)
        {
            _teamAppService.Add(teamViewModel);
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TeamViewModel teamViewModel)
        {
            if (id != teamViewModel.Id)
            {
                BadRequest();
            }

            _teamAppService.Update(teamViewModel);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _teamAppService.Remove(id);
        }
    }
}
