using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkAhead.Data.Entity
{
	public class Reservation
	{
		public int Id { get; set; }
		public DateTime ReservationStart { get; set; }
		public DateTime ReservationEnd { get; set; }
		public string RegistrationPlate { get; set; }
		public int ParkingSpotId { get; set; }
		public int UserId { get; set; }

		public virtual ParkingSpot ParkingSpot { get; set; }
		public virtual User User { get; set; }
	}

	public class ReservationConfigurationBuilder : IEntityTypeConfiguration<Reservation>
	{
		public void Configure()
		{

		}

		public void Configure(EntityTypeBuilder<Reservation> builder)
		{
			builder.ToTable(nameof(Reservation));
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.ParkingSpot)
				.WithMany()
				.HasForeignKey(x => x.ParkingSpotId)
				.OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(x => x.User)
				.WithMany()
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
