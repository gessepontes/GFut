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
    public class FieldItemController : ControllerBase
    {
        private readonly IFieldItemAppService _fieldAppService;

        public FieldItemController(IFieldItemAppService fieldAppService)
        {
            _fieldAppService = fieldAppService;
        }

        [HttpGet(Name = "GetFieldItem")]
        public async Task<IEnumerable<FieldItemViewModel>> Get()
        {
            return await _fieldAppService.GetAll();
        }

        [HttpGet("field/{FieldId}", Name = "GetSearchFieldItem")]
        public async Task<IEnumerable<FieldItemViewModel>> GetFieldItemByFieldId(int FieldId)
        {
            return await _fieldAppService.GetFieldItemByFieldId(FieldId);
        }

        [HttpGet("{id}", Name = "GetFieldItemById")]
        public async Task<FieldItemViewModel> Get(int id)
        {
            return await _fieldAppService.GetById(id);
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