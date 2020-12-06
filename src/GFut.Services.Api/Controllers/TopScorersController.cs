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
    public class TopScorersController : ControllerBase
    {
        private readonly ITopScorersAppService _topScorersAppService;

        public TopScorersController(ITopScorersAppService topScorersAppService)
        {
            _topScorersAppService = topScorersAppService;
        }

        [HttpGet("championship/{id}", Name = "GetTopScorersByChampionshipId")]
        public async Task<IEnumerable<TopScorersViewModel>> GetTopScorersByChampionshipId(int id)
        {
            return await _topScorersAppService.GetTopScorersByChampionshipId(id);
        }
    }
}