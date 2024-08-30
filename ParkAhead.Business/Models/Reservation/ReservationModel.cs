namespace ParkAhead.Business.Models.Reservation
{
	public class ReservationModel
	{
		public int Id { get; set; }
		public DateTime ReservationStart { get; set; }
		public DateTime ReservationEnd { get; set; }
		public string RegistrationPlate { get; set; }
		public int ParkingSpotId { get; set; }
	}
}
