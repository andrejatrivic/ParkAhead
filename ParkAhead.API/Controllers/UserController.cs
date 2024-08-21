using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkAhead.Business.Interfaces;
using ParkAhead.Business.Models.User;

namespace ParkAhead.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

		[HttpPost("Registration")]
		public async Task<string> Registration(UserRegistrationModel userRegistrationModel)
		{
			var response = await _service.Registration(userRegistrationModel);
			return response;
		}

		[HttpPost("Login")]
		public async Task<string> Login(UserModel userLoginModel)
		{
			var response = await _service.Login(userLoginModel);
			return response;
		}
	}
}
