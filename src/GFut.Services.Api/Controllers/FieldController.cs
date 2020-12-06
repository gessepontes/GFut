using System.Collections.Generic;
using System.Threading.Tasks;
using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
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

        [HttpGet(Name = "GetField")]
        public async Task<IEnumerable<FieldViewModel>> Get()
        {
            return await _fieldAppService.GetAll();
        }

        [HttpGet("{id}", Name = "GetFieldById")]
        public async Task<FieldViewModel> Get(int id)
        {
            return await _fieldAppService.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] FieldViewModel fieldViewModel)
        {
            _fieldAppService.Add(fieldViewModel);
        }

        [HttpPut(Name = "PutField")]
        public void Put([FromBody] FieldViewModel fieldViewModel)
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