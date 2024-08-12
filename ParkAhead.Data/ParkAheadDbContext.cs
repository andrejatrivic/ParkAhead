using Microsoft.EntityFrameworkCore;
using ParkAhead.Data.Entity;
using System.Reflection;

namespace ParkAhead.Data
{
	public class ParkAheadDbContext : DbContext
	{
        public ParkAheadDbContext(DbContextOptions<ParkAheadDbContext> options) : base(options)
        {
        }

        public DbSet<Parking> Parkings { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<ParkingSpotHistory> ParkingSpotHistory { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
