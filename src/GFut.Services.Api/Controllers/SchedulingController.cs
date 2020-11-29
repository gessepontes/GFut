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

        [HttpGet("{id}", Name = "GetSchedulingById")]
        public SchedulingViewModel Get(int id)
        {
            return _schedulingAppService.GetById(id);
        }

        [HttpGet("field/{FieldId}", Name = "GetSchedulingByFieldId")]
        public IEnumerable<SchedulingViewModel> GetSchedulingByFieldId(int FieldId)
        {
            return _schedulingAppService.GetSchedulingByFieldId(FieldId);
        }

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