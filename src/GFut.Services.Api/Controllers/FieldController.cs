using System.Collections.Generic;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IFieldAppService _fieldAppService;

        public FieldController(IFieldAppService fieldAppService)
        {
            _fieldAppService = fieldAppService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetField")]
        public IEnumerable<FieldViewModel> Get()
        {
            return _fieldAppService.GetAll();
        }

        [HttpGet("search/{search}", Name = "GetSearchField")]
        public IEnumerable<FieldViewModel> GetSearchField(string search)
        {
            return _fieldAppService.GetSearchField(search);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetFieldById")]
        public FieldViewModel Get(int id)
        {
            return _fieldAppService.GetById(id);
        }

        // POST: api/field
        [HttpPost]
        public void Post([FromBody] FieldViewModel fieldViewModel)
        {
            _fieldAppService.Add(fieldViewModel);
        }

        [HttpPut(Name = "PutField")]
        public void Put([FromBody]FieldViewModel fieldViewModel)
        {
            _fieldAppService.Update(fieldViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteField")]
        public void Delete(int id)
        {
            _fieldAppService.Remove(id); ;
        }

    }
}