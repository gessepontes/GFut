using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Person/[action]")]
    public class PersonController : Controller
    {
        private readonly IPersonAppService _personAppService;

        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetPerson")]
        public Task<IEnumerable<PersonViewModel>> Get()
        {
            return _personAppService.GetAll();
        }

        [HttpGet]
        public Task<IEnumerable<PersonViewModel>> PersonChampionshipDrop()
        {
            return _personAppService.GetPersonChampionshipDrop();
        }

        [HttpGet]
        public Task<IEnumerable<PersonViewModel>> PersonFieldDrop()
        {
            return _personAppService.GetPersonFieldDrop();
        }

        [HttpGet]
        public Task<IEnumerable<PersonViewModel>> PersonAllDrop()
        {
            return _personAppService.GetPersonAllDrop();
        }

        [HttpPost(Name = "PostPerson")]
        public void Post([FromBody]PersonViewModel personViewModel)
        {
            _personAppService.Add(personViewModel);
        }

        [HttpPut(Name = "PutPerson")]
        public void Put([FromBody]PersonViewModel personViewModel)
        {
            _personAppService.Update(personViewModel);
        }

        [HttpPut(Name = "PutUpdateProfile")]        
        public void PutUpdateProfile([FromBody] PersonViewModel personViewModel)
        {
            _personAppService.UpdateProfile(personViewModel);
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        public void Delete(int id)
        {
            _personAppService.Remove(id); ;
        }

    }
}