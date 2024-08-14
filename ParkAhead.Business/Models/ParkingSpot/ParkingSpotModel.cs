namespace ParkAhead.Business.Models.ParkingSpot
{
	public class ParkingSpotModel
	{
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public int ParkingSpotNumber { get; set; }
		public string ParkingName { get; set; }
		public string StatusName { get; set; }
	}
}
