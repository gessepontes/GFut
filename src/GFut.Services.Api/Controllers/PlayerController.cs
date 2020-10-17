using System.Collections.Generic;
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

        // GET: api/Player
        [HttpGet(Name = "GetPlayerAll")]
        public IEnumerable<PlayerViewModel> Get()
        {
            return _playerAppService.GetAll();
        }

        // GET: api/Player/5
        [HttpGet("{id}", Name = "GetPlayer")]
        public PlayerViewModel Get(int id)
        {
            return _playerAppService.GetById(id);
        }

        // POST: api/Player
        [HttpPost]
        public void Post([FromBody] PlayerViewModel playerViewModel)
        {
            _playerAppService.Add(playerViewModel);
        }

        // PUT: api/Player/5
        [HttpPut]
        public void Put([FromBody] PlayerViewModel playerViewModel)
        {
            _playerAppService.Update(playerViewModel);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _playerAppService.Remove(id);
        }

        [HttpGet("idTeam/{id}", Name = "GetPlayerTeam")]
        public IEnumerable<PlayerViewModel> GetPlayerTeam(int id)
        {
            return _playerAppService.GetPlayerTeam(id);
        }

        [HttpGet("Subscription/{IdSubscription}", Name = "GetPlayerTeamByIdSubscription")]
        public IEnumerable<PlayerViewModel> GetPlayerTeamByIdSubscription(int IdSubscription)
        {
            return _playerAppService.GetPlayerTeamByIdSubscription(IdSubscription);
        }
    }
}
