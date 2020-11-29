using System.Collections.Generic;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoraryController : ControllerBase
    {
        private readonly IHoraryAppService _horaryAppService;

        public HoraryController(IHoraryAppService horaryPriceAppService)
        {
            _horaryAppService = horaryPriceAppService;
        }

        [HttpGet(Name = "GetHorary")]
        public IEnumerable<HoraryViewModel> Get()
        {
            return _horaryAppService.GetAll();
        }

        [HttpGet("search/{search}", Name = "GetSearchHorary")]
        public IEnumerable<HoraryViewModel> GetSearchHorary(string search)
        {
            return _horaryAppService.GetSearchHorary(search);
        }

        [HttpGet("{id}", Name = "GetHoraryById")]
        public HoraryViewModel Get(int id)
        {
            return _horaryAppService.GetById(id);
        }

        [HttpGet("field/{FieldId}", Name = "GetHoraryByFieldId")]
        public IEnumerable<HoraryViewModel> GetHoraryByFieldId(int FieldId)
        {
            return _horaryAppService.GetHoraryByFieldId(FieldId);
        }

        [HttpPost]
        public void Post([FromBody] HoraryViewModel horaryPriceViewModel)
        {
            _horaryAppService.Add(horaryPriceViewModel);
        }

        [HttpPut(Name = "PutHorary")]
        public void Put([FromBody]HoraryViewModel horaryPriceViewModel)
        {
            _horaryAppService.Update(horaryPriceViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteHorary")]
        public void Delete(int id)
        {
            _horaryAppService.Remove(id); ;
        }

    }
}