using System.Collections.Generic;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldItemController : ControllerBase
    {
        private readonly IFieldItemAppService _fieldAppService;

        public FieldItemController(IFieldItemAppService fieldAppService)
        {
            _fieldAppService = fieldAppService;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetFieldItem")]
        public IEnumerable<FieldItemViewModel> Get()
        {
            return _fieldAppService.GetAll();
        }

        [HttpGet("field/{FieldId}", Name = "GetSearchFieldItem")]
        public IEnumerable<FieldItemViewModel> GetFieldItemByFieldId(int FieldId)
        {
            return _fieldAppService.GetFieldItemByFieldId(FieldId);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetFieldItemById")]
        public FieldItemViewModel Get(int id)
        {
            return _fieldAppService.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] FieldItemViewModel fieldViewModel)
        {
            _fieldAppService.Add(fieldViewModel);
        }

        [HttpPut(Name = "PutFieldItem")]
        public void Put([FromBody]FieldItemViewModel fieldViewModel)
        {
            _fieldAppService.Update(fieldViewModel);
        }

        [HttpDelete("{id}", Name = "DeleteFieldItem")]
        public void Delete(int id)
        {
            _fieldAppService.Remove(id); ;
        }

    }
}