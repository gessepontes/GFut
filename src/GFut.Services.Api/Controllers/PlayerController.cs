using System.Collections.Generic;
using System.Threading.Tasks;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerAppService _playerAppService;

        public PlayerController(IPlayerAppService playerAppService)
        {
            _playerAppService = playerAppService;
        }

        [HttpGet(Name = "GetPlayerAll")]
        public async Task<IEnumerable<PlayerViewModel>> Get()
        {
            return await _playerAppService.GetAll();
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public async Task<PlayerViewModel> Get(int id)
        {
            return await _playerAppService.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] PlayerViewModel playerViewModel)
        {
            _playerAppService.Add(playerViewModel);
        }

        [HttpPut]
        public void Put([FromBody] PlayerViewModel playerViewModel)
        {
            _playerAppService.Update(playerViewModel);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _playerAppService.Remove(id);
        }

        [HttpGet("idTeam/{id}", Name = "GetPlayerTeam")]
        public async Task<IEnumerable<PlayerViewModel>> GetPlayerTeam(int id)
        {
            return await _playerAppService.GetPlayerTeam(id);
        }

        [HttpGet("Subscription/{IdSubscription}", Name = "GetPlayerTeamByIdSubscription")]
        public async Task<IEnumerable<PlayerViewModel>> GetPlayerTeamByIdSubscription(int IdSubscription)
        {
            return await _playerAppService.GetPlayerTeamByIdSubscription(IdSubscription);
        }
    }
}
