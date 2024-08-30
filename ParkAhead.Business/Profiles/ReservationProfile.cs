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
            CreateMap<Data.Entity.Reservation, ReservationModel>();
        }
    }
}
