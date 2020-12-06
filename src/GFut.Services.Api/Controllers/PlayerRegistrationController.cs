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
    public class PlayerRegistrationController : ControllerBase
    {
        private readonly IPlayerRegistrationAppService _playerRegistrationAppService;

        public PlayerRegistrationController(IPlayerRegistrationAppService playerRegistrationAppService)
        {
            _playerRegistrationAppService = playerRegistrationAppService;
        }

        [HttpGet(Name = "GetPlayerRegistration")]
        public async Task<IEnumerable<PlayerRegistrationViewModel>> Get()
        {
            return await _playerRegistrationAppService.GetAll();
        }

        [HttpGet("{id}", Name = "GetPlayerRegistrationById")]
        public async Task<PlayerRegistrationViewModel> Get(int id)
        {
            return await _playerRegistrationAppService.GetById(id);
        }

        [HttpGet("championship/{id}", Name = "GetPlayerRegistrationByChampionshipId")]
        public async Task<IEnumerable<PlayerRegistrationViewModel>> GetPlayerRegistrationByChampionshipId(int id)
        {
            return await _playerRegistrationAppService.GetPlayerRegistrationByChampionshipId(id);
        }

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