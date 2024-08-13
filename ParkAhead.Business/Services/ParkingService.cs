using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ParkAhead.Business.Interfaces;
using ParkAhead.Business.Models.Parking;
using ParkAhead.Data.Repository;

namespace ParkAhead.Business.Services
{
	public class ParkingService : IParkingService
	{
		private readonly IRepository<Data.Entity.Parking> _repository;
		private readonly IMapper _mapper;
        public ParkingService(IRepository<Data.Entity.Parking> repository,
			IMapper mapper)
        {
			_repository = repository;	
			_mapper = mapper;
        }

        public async Task<ParkingModel> CreateParking(ParkingCreateUpdateRequestModel parking)
		{
			var parkingEntity = _mapper.Map<Data.Entity.Parking>(parking);
			_repository.Add(parkingEntity);
			await _repository.SaveAsync();

			return _mapper.Map<ParkingModel>(parking);
		}

		public async Task<IEnumerable<ParkingModel>> GetAllParkings()
		{
			var parkings = await _repository.GetAll()
				.ProjectTo<ParkingModel>(_mapper.ConfigurationProvider)
				.ToListAsync();
			return parkings;
		}

		public async Task<ParkingModel> GetParking(int id)
		{
			var parkingEntity = await _repository.GetByIdAsync(id);
			return _mapper.Map<ParkingModel>(parkingEntity);
		}

		public async Task<ParkingModel> UpdateParking(int id, ParkingCreateUpdateRequestModel parking)
		{
			var parkingEntity = await _repository.GetByIdAsync(id);
			if (parking is null) return null;

			_mapper.Map(parking, parkingEntity);
			_repository.Update(parkingEntity);
			await _repository.SaveAsync();

			return _mapper.Map<ParkingModel>(parkingEntity);
		}

		public async Task<ParkingModel> DeleteParking(int id)
		{
			var parkingEntity = await _repository.GetByIdAsync(id);
			if (parkingEntity is null) return null;

			_repository.Delete(parkingEntity);
			await _repository.SaveAsync();

			return _mapper.Map<ParkingModel>(parkingEntity);
		}		
	}
}
