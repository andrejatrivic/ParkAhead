using AutoMapper;
using ParkAhead.Business.Models.Reservation;

namespace ParkAhead.Business.Profiles
{
	public class ReservationProfile : Profile
	{
        public ReservationProfile()
        {
            CreateMap<ReservationRequestModel, Data.Entity.Reservation>();
            CreateMap<ReservationCreateModel, Data.Entity.Reservation>();
            CreateMap<Data.Entity.Reservation, ReservationModel>()
                .ForMember(dest => dest.ParkingSpotNumber, opt => opt.MapFrom(src => src.ParkingSpot.ParkingSpotNumber))
                .ForMember(dest => dest.ParkingName, opt => opt.MapFrom(src => src.ParkingSpot.Parking.Name));
        }
    }
}
