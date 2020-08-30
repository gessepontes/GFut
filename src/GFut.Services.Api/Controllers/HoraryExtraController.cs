using System.Collections.Generic;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoraryExtraController : ControllerBase
    {
        private readonly IHoraryExtraAppService _horaryAppService;

        public HoraryExtraController(IHoraryExtraAppService horaryPriceAppService)
        {
            _horaryAppService = horaryPriceAppService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetHoraryExtra")]
        public IEnumerable<HoraryExtraViewModel> Get()
        {
            return _horaryAppService.GetAll();
        }

        [HttpGet("search/{search}", Name = "GetSearchHoraryExtra")]
        public IEnumerable<HoraryExtraViewModel> GetSearchHoraryExtra(string search)
        {
            return _horaryAppService.GetSearchHoraryExtra(search);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetHoraryExtraById")]
        public HoraryExtraViewModel Get(int id)
        {
            return _horaryAppService.GetById(id);
        }

        // POST: api/horaryPrice
        [HttpPost]
        public void Post([FromBody] HoraryExtraViewModel horaryPriceViewModel)
        {
            _horaryAppService.Add(horaryPriceViewModel);
        }

        [HttpPut(Name = "PutHoraryExtra")]
        public void Put([FromBody]HoraryExtraViewModel horaryPriceViewModel)
        {
            _horaryAppService.Update(horaryPriceViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteHoraryExtra")]
        public void Delete(int id)
        {
            _horaryAppService.Remove(id); ;
        }

    }
}