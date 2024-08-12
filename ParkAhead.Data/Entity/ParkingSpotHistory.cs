using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkAhead.Data.Entity
{
	public class ParkingSpotHistory
	{
		public int Id { get; set; }
		public DateTime Timestamp { get; set; }
		public int ParkingSpotId { get; set; }	
		public int StatusId { get; set; }

		public virtual ParkingSpot ParkingSpot { get; set; }
		public virtual Status Status { get; set; }
	}

	public class ParkingSpotHistoryConfigurationBuilder : IEntityTypeConfiguration<ParkingSpotHistory>
	{
		public void Configure()
		{
		}

		public void Configure(EntityTypeBuilder<ParkingSpotHistory> builder)
		{
			builder.ToTable(nameof(ParkingSpotHistory));	
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.ParkingSpot)
				.WithMany()
				.HasForeignKey(x => x.ParkingSpotId)
				.OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(x => x.Status)
				.WithMany()
				.HasForeignKey(x => x.StatusId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
