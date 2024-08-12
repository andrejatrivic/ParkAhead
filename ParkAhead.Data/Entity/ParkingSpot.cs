namespace ParkAhead.Data.Entity
{
	public class ParkingSpot
	{
		public int Id { get; set; }
		public long Latitude { get; set; }
		public long Longitude { get; set; }
		public DateTime LastUpdated { get; set; }
		//FK status id
		//FK parking id
	}
}
