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
    public class HoraryExtraController : ControllerBase
    {
        private readonly IHoraryExtraAppService _horaryAppService;

        public HoraryExtraController(IHoraryExtraAppService horaryPriceAppService)
        {
            _horaryAppService = horaryPriceAppService;
        }

        [HttpGet(Name = "GetHoraryExtra")]
        public async Task<IEnumerable<HoraryExtraViewModel>> Get()
        {
            return await _horaryAppService.GetAll();
        }

        [HttpGet("{id}", Name = "GetHoraryExtraById")]
        public async Task<HoraryExtraViewModel> Get(int id)
        {
            return await _horaryAppService.GetById(id);
        }

        [HttpGet("field/{FieldId}", Name = "GetHoraryExtraByFieldId")]
        public async Task<IEnumerable<HoraryExtraViewModel>> GetHoraryExtraByFieldId(int FieldId)
        {
            return await _horaryAppService.GetHoraryExtraByFieldId(FieldId);
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