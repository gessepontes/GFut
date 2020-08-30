using System.Collections.Generic;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingAppService _schedulingAppService;

        public SchedulingController(ISchedulingAppService schedulingPriceAppService)
        {
            _schedulingAppService = schedulingPriceAppService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetScheduling")]
        public IEnumerable<SchedulingViewModel> Get()
        {
            return _schedulingAppService.GetAll();
        }

        [HttpGet("search/{search}", Name = "GetSearchScheduling")]
        public IEnumerable<SchedulingViewModel> GetSearchScheduling(string search)
        {
            return _schedulingAppService.GetSearchScheduling(search);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetSchedulingById")]
        public SchedulingViewModel Get(int id)
        {
            return _schedulingAppService.GetById(id);
        }

        // POST: api/schedulingPrice
        [HttpPost]
        public void Post([FromBody] SchedulingViewModel schedulingPriceViewModel)
        {
            _schedulingAppService.Add(schedulingPriceViewModel);
        }

        [HttpPut(Name = "PutScheduling")]
        public void Put([FromBody]SchedulingViewModel schedulingPriceViewModel)
        {
            _schedulingAppService.Update(schedulingPriceViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteScheduling")]
        public void Delete(int id)
        {
            _schedulingAppService.Remove(id); ;
        }

    }
}