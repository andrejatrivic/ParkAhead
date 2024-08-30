using AutoMapper;
using ParkAhead.Business.Interfaces;
using ParkAhead.Business.Models.Reservation;
using ParkAhead.Data.Entity;
using ParkAhead.Data.Repository;
using System.Diagnostics.Contracts;

namespace ParkAhead.Business.Services
{
	public class ReservationService : IReservationService
	{
		private const int STATUS_AVAILABLE = 1;
		private const int STATUS_OCCUPIED = 2;
		private const int STATUS_RESERVED = 3;

		private const string SUCCESS = "SUCCESS";
		private const string FAILED = "FAILED";

		private readonly IRepository<Reservation> _repository;
		private readonly IRepository<User> _userRepository;
		private readonly IParkingSpotService _parkingSpotService;
		private readonly IMapper _mapper;

        public ReservationService(IRepository<Reservation> repository,
			IRepository<User> userRepository,
			IParkingSpotService parkingSpotService,
			IMapper mapper)
        {
			_repository = repository;
			_userRepository = userRepository;
			_parkingSpotService = parkingSpotService;
			_mapper = mapper;
        }

		public async Task<string> ReserveParkingSpot(int spotId, string registrationPlate, string username)
		{
			if (username is null)
			{
				return FAILED;
			}
			if(_parkingSpotService.GetParkingSpotStatus(spotId).Result is not STATUS_AVAILABLE)
			{
				return FAILED;
			}

			var userId = _userRepository.GetAll().Where(x => x.Username.Equals(username)).Select(x => x.Id).FirstOrDefault();

			var reservation = new ReservationCreateModel
			{
				ParkingSpotId = spotId,
				RegistrationPlate = registrationPlate,
				ReservationStart = DateTime.Now,
				ReservationEnd = DateTime.Now.AddMinutes(30),
				UserId = userId
			};

			var reservationEntity = _mapper.Map<Reservation>(reservation);

			_repository.Add(reservationEntity);
			await _repository.SaveAsync();
			await _parkingSpotService.ChangeParkingSpotStatus(spotId, STATUS_RESERVED);
			return SUCCESS;
		}

		public async Task<string> CancelReservation(int reservationId, string username)
		{
			if (username is null)
			{
				return FAILED;
			}

			var userId = _userRepository.GetAll().Where(x => x.Username.Equals(username)).Select(x => x.Id).FirstOrDefault();
			if (userId == 0) 
			{
				return FAILED;
			}

			var reservationEntity = await _repository.GetByIdAsync(reservationId);

			if(DateTime.Now > reservationEntity.ReservationStart.AddMinutes(5) || reservationEntity.UserId != userId)
			{
				return FAILED;
			}

			_repository.Delete(reservationEntity);
			await _repository.SaveAsync();
			await _parkingSpotService.ChangeParkingSpotStatus(reservationEntity.ParkingSpotId, STATUS_AVAILABLE);
			return SUCCESS;
		}

		public async Task<string> ArrivedAtParkingSpot(int reservationId, string username)
		{
			if (username is null)
			{
				return FAILED;
			}

			var userId = _userRepository.GetAll().Where(x => x.Username.Equals(username)).Select(x => x.Id).FirstOrDefault();
			if (userId == 0)
			{
				return FAILED;
			}

			var reservationEntity = await _repository.GetByIdAsync(reservationId);

			if(DateTime.Now > reservationEntity.ReservationEnd)
			{
				return FAILED;
			}

			_repository.Delete(reservationEntity);
			await _repository.SaveAsync();
			_parkingSpotService.ChangeParkingSpotStatus(reservationEntity.ParkingSpotId, STATUS_OCCUPIED);
			return SUCCESS;
		}
	}
}
