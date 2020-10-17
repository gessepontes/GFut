using System.Collections.Generic;
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

        [AllowAnonymous]
        [HttpGet(Name = "GetGroupChampionship")]
        public IEnumerable<GroupChampionshipViewModel> Get()
        {
            return _groupChampionshipAppService.GetAll();
        }

         [AllowAnonymous]
        [HttpGet("{id}", Name = "GetGroupChampionshipById")]
        public GroupChampionshipViewModel Get(int id)
        {
            return _groupChampionshipAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpGet("championship/{id}", Name = "GetGroupChampionshipByChampionshipId")]
        public IEnumerable<GroupChampionshipViewModel> GetGroupChampionshipByChampionshipId(int id)
        {
            return _groupChampionshipAppService.GetGroupChampionshipByChampionshipId(id);
        }

        // POST: api/groupChampionship
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