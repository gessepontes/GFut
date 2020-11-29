using System.Collections.Generic;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchSummaryController : ControllerBase
    {
        private readonly IMatchSummaryAppService _matchSummaryAppService;
        private readonly IMatchChampionshipAppService _matchChampionshipAppService;

        public MatchSummaryController(IMatchSummaryAppService matchSummaryAppService, 
            IMatchChampionshipAppService matchChampionshipAppService)
        {
            _matchSummaryAppService = matchSummaryAppService;
            _matchChampionshipAppService = matchChampionshipAppService;

        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetMatchSummaryById")]
        public MatchSummaryViewModel Get(int id)
        {
            return _matchSummaryAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpGet("championship/{id}", Name = "GetMatchSummaryByChampionshipId")]
        public IEnumerable<MatchChampionshipViewModel> GetMatchSummaryByChampionshipId(int id)
        {
            return _matchChampionshipAppService.GetMatchChampionshipByChampionshipId(id);
        }

        [HttpPut(Name = "PutMatchSummary")]
        public void Put([FromBody]MatchSummaryViewModel matchChampionshipViewModel)
        {
            _matchSummaryAppService.Update(matchChampionshipViewModel);
        }
    }
}