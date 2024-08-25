using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ParkAhead.Business.Interfaces;
using ParkAhead.Business.Models.Parking;
using ParkAhead.Business.Models.ParkingSpot;
using ParkAhead.Data.Entity;
using ParkAhead.Data.Repository;

namespace ParkAhead.Business.Services
{
	public class ParkingSpotService : IParkingSpotService
	{
		private readonly IRepository<ParkingSpot> _repository;
		private readonly IMapper _mapper;
        public ParkingSpotService(IRepository<ParkingSpot> repository,
			IMapper mapper)
        {
			_repository = repository;
			_mapper = mapper;	
        }

		public async Task<IEnumerable<ParkingSpotModel>> GetParkingSpots()
		{
			var parkingSpots = await _repository.GetAll()
				.Include(x => x.Parking)
				.Include(x => x.Status)
				.ToListAsync();

			return _mapper.Map<IEnumerable<ParkingSpotModel>>(parkingSpots);
		}

		public async Task<IEnumerable<ParkingSpotModel>> GetParkingSpotsByParkingId(int id)
		{
			var parkingSpots = await _repository.GetAll()
				.Where(x => x.ParkingId == id)
				.Include(x => x.Parking)   
				.Include(x => x.Status)   
				.ToListAsync();

			return _mapper.Map<IEnumerable<ParkingSpotModel>>(parkingSpots);
		}

		public async Task<int> ChangeParkingSpotStatus(int parkingSpotId, ParkingSpotStatusUpdateModel parkingSpotStatus)
		{
			var parkingSpotEntity = await _repository.GetByIdAsync(parkingSpotId);
			if (parkingSpotEntity is null) return 0;

			_mapper.Map(parkingSpotStatus, parkingSpotEntity);
			_repository.Update(parkingSpotEntity);
			await _repository.SaveAsync();

			return parkingSpotEntity.StatusId;
		}

		public async Task<int> ChangeParkingSpotStatus(int parkingSpotId, int status)
		{
			var parkingSpotEntity = await _repository.GetByIdAsync(parkingSpotId);
			if (parkingSpotEntity is null) return 0;

			var parkingSpotStatus = new ParkingSpotStatusUpdateModel
			{
				StatusId = status,
			};

			_mapper.Map(parkingSpotStatus, parkingSpotEntity);
			_repository.Update(parkingSpotEntity);
			await _repository.SaveAsync();

			return parkingSpotEntity.StatusId;
		}

		public async Task<int> GetParkingSpotStatus(int id)
		{
			var parkingSpotStatus = await _repository.GetByIdAsync(id);
			if(parkingSpotStatus is not null)
			{
				return parkingSpotStatus.StatusId;
			} else return 0;
		}
	}
}
