using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkAhead.Business.Interfaces;
using ParkAhead.Business.Models.Parking;
using ParkAhead.Business.Models.ParkingSpot;

namespace ParkAhead.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ParkingSpotController : ControllerBase
	{
		private readonly IParkingSpotService _service;

        public ParkingSpotController(IParkingSpotService service)
        {
			_service = service;
        }

		[HttpGet("GetParkingsSpots")]
		public async Task<IEnumerable<ParkingSpotModel>> GetParkingSpots()
		{
			var parkingSpots = await _service.GetParkingSpots();
			return parkingSpots;
		}

		[HttpGet("GetParkingsSpots/{id}")]
		public async Task<IEnumerable<ParkingSpotModel>> GetParkingSpots(int id)
		{
			var parkingSpots = await _service.GetParkingSpotsByParkingId(id);
			return parkingSpots;
		}

		[HttpPut("ChangeParkingSpotStatus/{parkingSpotId}")]
		public async Task<int> ChangeParkingSpotStatus(int parkingSpotId, ParkingSpotStatusUpdateModel parkingSpotStatusModel)
		{
			var parkingSpotStatus = await _service.ChangeParkingSpotStatus(parkingSpotId, parkingSpotStatusModel);
			return parkingSpotStatus;	
		}

		[HttpGet("GetParkingSpotStatus/{id}")]
		public async Task<int> GetParkingSpotStatus(int id)
		{
			var parkingSpotStatus = await _service.GetParkingSpotStatus(id);
			return parkingSpotStatus;
		}
	}
}
