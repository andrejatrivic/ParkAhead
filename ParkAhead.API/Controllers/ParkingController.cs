using Microsoft.AspNetCore.Mvc;
using ParkAhead.Business.Interfaces;
using ParkAhead.Business.Models.Parking;

namespace ParkAhead.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ParkingController : ControllerBase
	{
        private readonly IParkingService _service;
        public ParkingController(IParkingService service)
        {
            _service = service; 
        }

		[HttpPost("CreateParking")]
		public async Task<ParkingModel> CreateMenu(ParkingCreateUpdateRequestModel parking)
		{
			var createdParking = await _service.CreateParking(parking);
			return createdParking;
		}

		[HttpGet("GetParkings")]
		public async Task<IEnumerable<ParkingModel>> GetParkings()
		{
			var parkings = await _service.GetAllParkings();
			return parkings;
		}

		[HttpGet("GetParking/{id}")]
		public async Task<ParkingModel> GetParking(int id)
		{
			var parking = await _service.GetParking(id);
			return parking;	
		}

		[HttpPut("UpdateParking/{id}")]
		public async Task<ParkingModel> UpdateParking(int id, ParkingCreateUpdateRequestModel parking)
		{
			var updatedParking = await _service.UpdateParking(id, parking);
			return updatedParking;
		}

		[HttpDelete("DeleteParking/{id}")]
		public async Task<ParkingModel> DeleteParking(int id)
		{
			var deletedParking = await _service.DeleteParking(id);
			return deletedParking;
		}
	}
}
