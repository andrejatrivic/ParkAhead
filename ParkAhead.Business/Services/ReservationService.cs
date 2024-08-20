using ParkAhead.Business.Interfaces;
using ParkAhead.Data.Entity;
using ParkAhead.Data.Repository;

namespace ParkAhead.Business.Services
{
	public class ReservationService : IReservationService
	{
		private readonly IRepository<Reservation> _repository;

        public ReservationService(IRepository<Reservation> repository)
        {
			_repository = repository;
        }

        public Task<bool> ReserveParkingSpot(int id)
		{
			throw new NotImplementedException();
		}
	}
}
