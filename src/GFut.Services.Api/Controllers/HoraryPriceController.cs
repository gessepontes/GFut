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
    public class HoraryPriceController : ControllerBase
    {
        private readonly IHoraryPriceAppService _horaryPriceAppService;

        public HoraryPriceController(IHoraryPriceAppService horaryPriceAppService)
        {
            _horaryPriceAppService = horaryPriceAppService;
        }

        [HttpGet(Name = "GetHoraryPrice")]
        public async Task<IEnumerable<HoraryPriceViewModel>> Get()
        {
            return await _horaryPriceAppService.GetAll();
        }

        [HttpGet("field/{FieldId}", Name = "GetHoraryPriceByFieldId")]
        public async Task<IEnumerable<HoraryPriceViewModel>> GetHoraryPriceByFieldId(int FieldId)
        {
            return await _horaryPriceAppService.GetHoraryPriceByFieldId(FieldId);
        }

        [HttpGet("{id}", Name = "GetHoraryPriceById")]
        public async Task<HoraryPriceViewModel> Get(int id)
        {
            return await _horaryPriceAppService.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] HoraryPriceViewModel horaryPriceViewModel)
        {
            _horaryPriceAppService.Add(horaryPriceViewModel);
        }

        [HttpPut(Name = "PutHoraryPrice")]
        public void Put([FromBody]HoraryPriceViewModel horaryPriceViewModel)
        {
            _horaryPriceAppService.Update(horaryPriceViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteHoraryPrice")]
        public void Delete(int id)
        {
            _horaryPriceAppService.Remove(id); ;
        }

    }
}