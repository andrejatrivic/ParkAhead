using ParkAhead.Business.Models.ParkingSpot;

namespace ParkAhead.Business.Interfaces
{
	public interface IParkingSpotService
	{
		Task<IEnumerable<ParkingSpotModel>> GetParkingSpots();
		Task<IEnumerable<ParkingSpotModel>> GetParkingSpotsByParkingId(int id);
		Task<int> ChangeParkingSpotStatus(int parkingSpotId, ParkingSpotStatusUpdateModel parkingSpotStatus);
		Task<int> ChangeParkingSpotStatus(int parkingSpotId, int parkingSpotStatus);
		Task<int> GetParkingSpotStatus(int id);
	}
}
