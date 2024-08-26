using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("reservation/{spotId}/{registrationPlate}")]
		public async Task<bool> ReserveParkingSpot(int spotId, string registrationPlate)
		{
			var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
			var result = await _service.ReserveParkingSpot(spotId, registrationPlate, username);
			return result;
		}

		[HttpDelete("reservation/{reservationId}")]
		public async Task<bool> CancelReservation(int reservationId)
		{
			var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
			var result = await _service.CancelReservation(reservationId, username);
			return result;
		}

		[HttpPut("reservation/{reservationId}/arrival")]
		public async Task<bool> ArrivedAtParkingSpot(int reservationId)
		{
			var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
			var result = await _service.ArrivedAtParkingSpot(reservationId, username);
			return result;
		}
	}
}
