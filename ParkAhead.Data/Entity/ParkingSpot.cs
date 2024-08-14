using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ParkAhead.Data.Entity
{
	public class ParkingSpot
	{
		public int Id { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public DateTime LastUpdated { get; set; }
		public int ParkingSpotNumber { get; set; }
		public int ParkingId { get; set; }
		public int StatusId { get; set; }

		public virtual Status Status { get; set; }
		public virtual Parking Parking { get; set; }
	}

	public class ParkingSpotConfigurationBuilder : IEntityTypeConfiguration<ParkingSpot>
	{
		public void Configure()
		{
		}

		public void Configure(EntityTypeBuilder<ParkingSpot> builder)
		{
			builder.ToTable(nameof(ParkingSpot));
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Latitude)
				.HasColumnType("DECIMAL(18, 8)")
				.IsRequired(); 
			builder.Property(x => x.Longitude)
				.HasColumnType("DECIMAL(18, 8)")
				.IsRequired();
			builder.HasOne(x => x.Parking)
				.WithMany()
				.HasForeignKey(x => x.ParkingId)
				.OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(x => x.Status)
				.WithMany()
				.HasForeignKey(x => x.StatusId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
