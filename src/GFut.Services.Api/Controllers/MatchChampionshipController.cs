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
    public class MatchChampionshipController : ControllerBase
    {
        private readonly IMatchChampionshipAppService _matchChampionshipAppService;

        public MatchChampionshipController(IMatchChampionshipAppService matchChampionshipAppService)
        {
            _matchChampionshipAppService = matchChampionshipAppService;
        }

        [HttpGet(Name = "GetMatchChampionship")]
        public async Task<IEnumerable<MatchChampionshipViewModel>> Get()
        {
            return await _matchChampionshipAppService.GetAll();
        }

        [HttpGet("{id}", Name = "GetMatchChampionshipById")]
        public async Task<MatchChampionshipViewModel> GetById(int id)
        {
            return await _matchChampionshipAppService.GetById(id);
        }

        [HttpGet("championship/{id}", Name = "GetMatchChampionshipByChampionshipId")]
        public async Task<IEnumerable<MatchChampionshipViewModel>> GetMatchChampionshipByChampionshipId(int id)
        {
            return await _matchChampionshipAppService.GetMatchChampionshipByChampionshipId(id);
        }

        [HttpPost]
        public void Post([FromBody] MatchChampionshipViewModel matchChampionshipViewModel)
        {
            _matchChampionshipAppService.Add(matchChampionshipViewModel);
        }

        [HttpPost("automaticMatchChampionship")]
        public void PostAutomaticMatchChampionship(int championshipId, int groupId)
        {
            _matchChampionshipAppService.AutomaticMatchChampionship(championshipId, groupId);
        }

        [HttpPut(Name = "PutMatchChampionship")]
        public void Put([FromBody] MatchChampionshipViewModel matchChampionshipViewModel)
        {
            _matchChampionshipAppService.Update(matchChampionshipViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteMatchChampionship")]
        public void Delete(int id)
        {
            _matchChampionshipAppService.Remove(id); ;
        }

    }
}