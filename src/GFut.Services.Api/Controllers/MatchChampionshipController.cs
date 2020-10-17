using System.Collections.Generic;
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

        [AllowAnonymous]
        [HttpGet(Name = "GetMatchChampionship")]
        public IEnumerable<MatchChampionshipViewModel> Get()
        {
            return _matchChampionshipAppService.GetAll();
        }

         [AllowAnonymous]
        [HttpGet("{id}", Name = "GetMatchChampionshipById")]
        public MatchChampionshipViewModel Get(int id)
        {
            return _matchChampionshipAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpGet("championship/{id}", Name = "GetMatchChampionshipByChampionshipId")]
        public IEnumerable<MatchChampionshipViewModel> GetMatchChampionshipByChampionshipId(int id)
        {
            return _matchChampionshipAppService.GetMatchChampionshipByChampionshipId(id);
        }

        // POST: api/matchChampionship
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
        public void Put([FromBody]MatchChampionshipViewModel matchChampionshipViewModel)
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