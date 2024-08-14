using AutoMapper;
using ParkAhead.Business.Models.ParkingSpot;

namespace ParkAhead.Business.Profiles
{
	public class ParkingSpotProfile : Profile
	{
        public ParkingSpotProfile()
        {
			CreateMap<Data.Entity.ParkingSpot, ParkingSpotModel>();
			CreateMap<Data.Entity.ParkingSpot, ParkingSpotModel>()
				.ForMember(dest => dest.ParkingName, opt => opt.MapFrom(src => src.Parking.Name))
				.ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name));
			CreateMap<ParkingSpotStatusUpdateModel, Data.Entity.ParkingSpot>();
		}
    }
}
