namespace ParkAhead.Business.Models.ParkingSpot
{
	public class ParkingSpotModel
	{
		public int Id { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public int ParkingSpotNumber { get; set; }
		public string ParkingName { get; set; }
		public string StatusName { get; set; }
		public int StatusId {  get; set; }
		public int ImageX { get; set; }
		public int ImageY { get; set; }
	}
}
