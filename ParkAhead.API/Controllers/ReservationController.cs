using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkAhead.Business.Interfaces;
using System.Security.Claims;

namespace ParkAhead.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ReservationController : ControllerBase
	{
        private readonly IReservationService _service;
        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpPost("Reservation/{spotId}/{registrationPlate}")]
		public async Task<bool> ReserveParkingSpot(int spotId, string registrationPlate)
		{
			string username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
			var result = await _service.ReserveParkingSpot(spotId, registrationPlate, username);
			return result;
		}

	}
}
