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
    public class StandingsController : ControllerBase
    {
        private readonly IStandingsAppService _standingsAppService;

        public StandingsController(IStandingsAppService standingsAppService)
        {
            _standingsAppService = standingsAppService;
        }

        [HttpGet("championship/{id}", Name = "GetStandingsByChampionshipId")]
        public async Task<IEnumerable<List<StandingsViewModel>>> GetStandingsByChampionshipId(int id)
        {
            return await _standingsAppService.GetStandingsByChampionshipId(id);
        }
    }
}