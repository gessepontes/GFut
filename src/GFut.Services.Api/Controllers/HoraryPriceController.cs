using System.Collections.Generic;
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

        [AllowAnonymous]
        [HttpGet(Name = "GetHoraryPrice")]
        public IEnumerable<HoraryPriceViewModel> Get()
        {
            return _horaryPriceAppService.GetAll();
        }

        [HttpGet("search/{search}", Name = "GetSearchHoraryPrice")]
        public IEnumerable<HoraryPriceViewModel> GetSearchHoraryPrice(string search)
        {
            return _horaryPriceAppService.GetSearchHoraryPrice(search);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetHoraryPriceById")]
        public HoraryPriceViewModel Get(int id)
        {
            return _horaryPriceAppService.GetById(id);
        }

        // POST: api/horaryPrice
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