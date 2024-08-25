namespace ParkAhead.Business.Interfaces
{
	public interface IReservationService
	{
		Task<bool> ReserveParkingSpot(int spotId, string registrationPlate, string username);
	}
}
