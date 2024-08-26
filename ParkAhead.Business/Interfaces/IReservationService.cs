namespace ParkAhead.Business.Interfaces
{
	public interface IReservationService
	{
		Task<bool> ReserveParkingSpot(int spotId, string registrationPlate, string username);
		Task<bool> CancelReservation(int reservationId, string username);
		Task<bool> ArrivedAtParkingSpot(int reservationId, string username);
	}
}
