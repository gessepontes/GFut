using System.Collections.Generic;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Person")]
    public class PersonController : Controller
    {
        private readonly IPersonAppService _personAppService;

        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetPerson")]
        public IEnumerable<PersonViewModel> Get()
        {
            return _personAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetPersonById")]
        public PersonViewModel Get(int id)
        {
            return _personAppService.GetById(id);
        }

        [HttpPost(Name = "PostPerson")]
        public void Post([FromBody]PersonViewModel personViewModel)
        {
            _personAppService.Register(personViewModel);
        }

        [HttpPut(Name = "PutPerson")]
        public void Put([FromBody]PersonViewModel personViewModel)
        {
            _personAppService.Update(personViewModel);
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        public void Delete(int id)
        {
            _personAppService.Remove(id); ;
        }

    }
}