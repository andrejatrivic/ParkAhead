using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkAhead.Business.Interfaces;

namespace ParkAhead.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CheckReservationController : ControllerBase
	{
		private readonly IReservationService _service;
		public CheckReservationController(IReservationService service)
        {
			_service = service;
        }

        [HttpPut("check-reservations")]

		public async Task CheckReservation()
		{
			await _service.CheckReservations();
		}
	}
}
