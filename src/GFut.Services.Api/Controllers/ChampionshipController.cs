﻿using System.Collections.Generic;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        private readonly IChampionshipAppService _championshipAppService;

        public ChampionshipController(IChampionshipAppService championshipAppService)
        {
            _championshipAppService = championshipAppService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetChampionship")]
        public IEnumerable<ChampionshipViewModel> Get()
        {
            return _championshipAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetChampionshipById")]
        public ChampionshipViewModel Get(int id)
        {
            return _championshipAppService.GetById(id);
        }

        [HttpPut(Name = "PutChampionship")]
        public void Put([FromBody]ChampionshipViewModel championshipViewModel)
        {
            _championshipAppService.Update(championshipViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteChampionship")]
        public void Delete(int id)
        {
            _championshipAppService.Remove(id); ;
        }

    }
}