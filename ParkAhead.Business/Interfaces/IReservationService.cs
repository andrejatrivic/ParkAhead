namespace ParkAhead.Business.Interfaces
{
	public interface IReservationService
	{
		Task<bool> ReserveParkingSpot(int id);
	}
}
