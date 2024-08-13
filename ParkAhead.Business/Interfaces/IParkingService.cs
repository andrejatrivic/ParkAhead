using ParkAhead.Business.Models.Parking;

namespace ParkAhead.Business.Interfaces
{
	public interface IParkingService
	{
		Task<ParkingModel> CreateParking(ParkingCreateUpdateRequestModel parking);

		Task<IEnumerable<ParkingModel>> GetAllParkings();
		Task<ParkingModel> GetParking(int id);

		Task<ParkingModel> UpdateParking(int id, ParkingCreateUpdateRequestModel parking);

		Task<ParkingModel> DeleteParking(int id);
	}
}
