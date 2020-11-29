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

        [HttpGet("{id}", Name = "GetHoraryExtraById")]
        public HoraryExtraViewModel Get(int id)
        {
            return _horaryAppService.GetById(id);
        }

        [HttpGet("field/{FieldId}", Name = "GetHoraryExtraByFieldId")]
        public IEnumerable<HoraryExtraViewModel> GetHoraryExtraByFieldId(int FieldId)
        {
            return _horaryAppService.GetHoraryExtraByFieldId(FieldId);
        }

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