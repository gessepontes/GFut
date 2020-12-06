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
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingAppService _schedulingAppService;

        public SchedulingController(ISchedulingAppService schedulingPriceAppService)
        {
            _schedulingAppService = schedulingPriceAppService;
        }

        [HttpGet(Name = "GetScheduling")]
        public async Task<IEnumerable<SchedulingViewModel>> Get()
        {
            return await _schedulingAppService.GetAll();
        }

        [HttpGet("{id}", Name = "GetSchedulingById")]
        public async Task<SchedulingViewModel> Get(int id)
        {
            return await _schedulingAppService.GetById(id);
        }

        [HttpGet("field/{FieldId}", Name = "GetSchedulingByFieldId")]
        public async Task<IEnumerable<SchedulingViewModel>> GetSchedulingByFieldId(int FieldId)
        {
            return await _schedulingAppService.GetSchedulingByFieldId(FieldId);
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