using System.Collections.Generic;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerRegistrationController : ControllerBase
    {
        private readonly IPlayerRegistrationAppService _playerRegistrationAppService;

        public PlayerRegistrationController(IPlayerRegistrationAppService playerRegistrationAppService)
        {
            _playerRegistrationAppService = playerRegistrationAppService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetPlayerRegistration")]
        public IEnumerable<PlayerRegistrationViewModel> Get()
        {
            return _playerRegistrationAppService.GetAll();
        }

         [AllowAnonymous]
        [HttpGet("{id}", Name = "GetPlayerRegistrationById")]
        public PlayerRegistrationViewModel Get(int id)
        {
            return _playerRegistrationAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpGet("championship/{id}", Name = "GetPlayerRegistrationByChampionshipId")]
        public IEnumerable<PlayerRegistrationViewModel> GetPlayerRegistrationByChampionshipId(int id)
        {
            return _playerRegistrationAppService.GetPlayerRegistrationByChampionshipId(id);
        }

        // POST: api/playerRegistration
        [HttpPost]
        public void Post([FromBody] PlayerRegistrationViewModel playerRegistrationViewModel)
        {
            _playerRegistrationAppService.Add(playerRegistrationViewModel);
        }

        [HttpPut(Name = "PutPlayerRegistration")]
        public void Put([FromBody]PlayerRegistrationViewModel playerRegistrationViewModel)
        {
            _playerRegistrationAppService.Update(playerRegistrationViewModel);
        }

        [HttpDelete("{id}", Name = "DeletePlayerRegistration")]
        public void Delete(int id)
        {
            _playerRegistrationAppService.Remove(id); ;
        }

    }
}