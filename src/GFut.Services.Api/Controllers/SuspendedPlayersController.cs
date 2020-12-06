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
    public class SuspendedPlayersController : ControllerBase
    {
        private readonly ISuspendedPlayersAppService _suspendedPlayersAppService;

        public SuspendedPlayersController(ISuspendedPlayersAppService suspendedPlayersAppService)
        {
            _suspendedPlayersAppService = suspendedPlayersAppService;
        }

        [AllowAnonymous]
        [HttpGet("championship/{id}/{rodada}", Name = "GetSuspendedPlayersByChampionshipId")]
        public async Task<IEnumerable<SuspendedPlayersViewModel>> GetSuspendedPlayersByChampionshipId(int id, int rodada)
        {
            return await _suspendedPlayersAppService.GetSuspendedPlayersByChampionshipId(id, rodada);
        }
    }
}