using System.Collections.Generic;
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

        [AllowAnonymous]
        [HttpGet(Name = "GetSubscription")]
        public IEnumerable<SubscriptionViewModel> Get()
        {
            return _subscriptionAppService.GetAll();
        }

         [AllowAnonymous]
        [HttpGet("{id}", Name = "GetSubscriptionById")]
        public SubscriptionViewModel Get(int id)
        {
            return _subscriptionAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpGet("championship/{id}", Name = "GetSubscriptionByChampionshipId")]
        public IEnumerable<SubscriptionViewModel> GetSubscriptionByChampionshipId(int id)
        {
            return _subscriptionAppService.GetSubscriptionByChampionshipId(id);
        }

        // POST: api/subscription
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