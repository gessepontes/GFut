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
    public class GroupChampionshipController : ControllerBase
    {
        private readonly IGroupChampionshipAppService _groupChampionshipAppService;

        public GroupChampionshipController(IGroupChampionshipAppService groupChampionshipAppService)
        {
            _groupChampionshipAppService = groupChampionshipAppService;
        }

        [HttpGet(Name = "GetGroupChampionship")]
        public async Task<IEnumerable<GroupChampionshipViewModel>> Get()
        {
            return await _groupChampionshipAppService.GetAll();
        }

        [HttpGet("{id}", Name = "GetGroupChampionshipById")]
        public async Task<GroupChampionshipViewModel> Get(int id)
        {
            return await _groupChampionshipAppService.GetById(id);
        }

        [HttpGet("championship/{id}", Name = "GetGroupChampionshipByChampionshipId")]
        public async Task<IEnumerable<GroupChampionshipViewModel>> GetGroupChampionshipByChampionshipId(int id)
        {
            return await _groupChampionshipAppService.GetGroupChampionshipByChampionshipId(id);
        }

        [HttpPost]
        public void Post([FromBody] GroupChampionshipViewModel groupChampionshipViewModel)
        {
            _groupChampionshipAppService.Add(groupChampionshipViewModel);
        }

        [HttpPost("automaticGroupChampionship")]
        public void PostAutomaticGroupChampionship(int championshipId, int quantity)
        {
            _groupChampionshipAppService.AutomaticGroupChampionship(championshipId, quantity);
        }

        [HttpPut(Name = "PutGroupChampionship")]
        public void Put([FromBody]GroupChampionshipViewModel groupChampionshipViewModel)
        {
            _groupChampionshipAppService.Update(groupChampionshipViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteGroupChampionship")]
        public void Delete(int id)
        {
            _groupChampionshipAppService.Remove(id); ;
        }

    }
}