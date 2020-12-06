using System.Collections.Generic;
using System.Threading.Tasks;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        private readonly IChampionshipAppService _championshipAppService;

        public ChampionshipController(IChampionshipAppService championshipAppService)
        {
            _championshipAppService = championshipAppService;
        }

        [HttpGet(Name = "GetChampionship")]
        public async Task<IEnumerable<ChampionshipViewModel>> Get()
        {
            return await _championshipAppService.GetAll();
        }

        [HttpGet("Group/")]
        public async Task<IEnumerable<ChampionshipViewModel>> GetGroupChampionship()
        {
            return await _championshipAppService.GetGroupChampionship();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetChampionshipById")]
        public async Task<ChampionshipViewModel> Get(int id)
        {
            return await _championshipAppService.GetById(id);
        }

        [HttpPut(Name = "PutChampionship")]
        public void Put([FromBody] ChampionshipViewModel championshipViewModel)
        {
            _championshipAppService.Update(championshipViewModel);
        }

        // POST: api/championship
        [HttpPost]
        public void Post([FromBody] ChampionshipViewModel championshipViewModel)
        {
            _championshipAppService.Add(championshipViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteChampionship")]
        public void Delete(int id)
        {
            _championshipAppService.Remove(id); ;
        }

    }
}