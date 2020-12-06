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
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionAppService _subscriptionAppService;

        public SubscriptionController(ISubscriptionAppService subscriptionAppService)
        {
            _subscriptionAppService = subscriptionAppService;
        }

        [HttpGet(Name = "GetSubscription")]
        public async Task<IEnumerable<SubscriptionViewModel>> Get()
        {
            return await _subscriptionAppService.GetAll();
        }

        [HttpGet("{id}", Name = "GetSubscriptionById")]
        public async Task<SubscriptionViewModel> Get(int id)
        {
            return await _subscriptionAppService.GetById(id);
        }

        [HttpGet("championship/{id}", Name = "GetSubscriptionByChampionshipId")]
        public async Task<IEnumerable<SubscriptionViewModel>> GetSubscriptionByChampionshipId(int id)
        {
            return await _subscriptionAppService.GetSubscriptionByChampionshipId(id);
        }

        [HttpPost]
        public void Post([FromBody] SubscriptionViewModel subscriptionViewModel)
        {
            _subscriptionAppService.Add(subscriptionViewModel);
        }

        [HttpPut(Name = "PutSubscription")]
        public void Put([FromBody]SubscriptionViewModel subscriptionViewModel)
        {
            _subscriptionAppService.Update(subscriptionViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteSubscription")]
        public void Delete(int id)
        {
            _subscriptionAppService.Remove(id); ;
        }

    }
}