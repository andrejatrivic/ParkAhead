using ParkAhead.Business.Models.Reservation;

namespace ParkAhead.Business.Interfaces
{
	public interface IReservationService
	{
		Task<string> ReserveParkingSpot(int spotId, string registrationPlate, string username);
		Task<string> CancelReservation(int reservationId, string username);
		Task<string> ArrivedAtParkingSpot(int reservationId, string username);
		Task<ReservationModel> GetReservation(string username);
	}
}
