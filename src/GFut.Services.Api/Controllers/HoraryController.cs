using System;
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
    public class HoraryController : ControllerBase
    {
        private readonly IHoraryAppService _horaryAppService;

        public HoraryController(IHoraryAppService horaryPriceAppService)
        {
            _horaryAppService = horaryPriceAppService;
        }

        [HttpGet(Name = "GetHorary")]
        public async Task<IEnumerable<HoraryViewModel>> Get()
        {
            return await _horaryAppService.GetAll();
        }

        [HttpGet("{id}", Name = "GetHoraryById")]
        public async Task<HoraryViewModel> Get(int id)
        {
            return await _horaryAppService.GetById(id);
        }

        [HttpGet("field/{fieldId}", Name = "GetHoraryByFieldId")]
        public async Task<IEnumerable<HoraryViewModel>> GetHoraryByFieldId(int fieldId)
        {
            return await _horaryAppService.GetHoraryByFieldId(fieldId);
        }

        [HttpGet("HoraryDrop/{type}/{fieldItem}/{date}/{horaryId}", Name = "GetHoraryDrop")]
        public async Task<IEnumerable<HoraryViewModel>> GetHoraryDrop(int type, int fieldItem, DateTime date, int horaryId)
        {
            return await _horaryAppService.GetHoraryDrop(type, fieldItem, date, horaryId);
        }

        [HttpPost]
        public void Post([FromBody] HoraryViewModel horaryPriceViewModel)
        {
            _horaryAppService.Add(horaryPriceViewModel);
        }

        [HttpPut(Name = "PutHorary")]
        public void Put([FromBody] HoraryViewModel horaryPriceViewModel)
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