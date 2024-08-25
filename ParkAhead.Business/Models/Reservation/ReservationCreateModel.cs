namespace ParkAhead.Business.Models.Reservation
{
	public class ReservationCreateModel
	{
		public DateTime ReservationStart { get; set; }
		public DateTime ReservationEnd { get; set; }
		public string RegistrationPlate { get; set; }
		public int ParkingSpotId { get; set; }
		public int UserId { get; set; }
	}
}
