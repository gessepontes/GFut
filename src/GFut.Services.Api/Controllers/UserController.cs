using GFut.Application.Interfaces;
using GFut.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GFut.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost("signup")]
        public void SignUp([FromBody]UserViewModel userViewModel)
        {
            _userAppService.SignUp(userViewModel);
        }

        [HttpPost("signin")]
        public async Task<PersonViewModel> SignIn([FromBody]UserViewModel userViewModel)
        {
            return await _userAppService.SignIn(userViewModel);
        }

        [HttpPut(Name = "PutUser")]
        public void Put([FromBody]UserViewModel userViewModel)
        {
            _userAppService.UpdateUser(userViewModel);
        }
    }
}