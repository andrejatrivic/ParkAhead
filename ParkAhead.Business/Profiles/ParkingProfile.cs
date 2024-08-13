using AutoMapper;
using ParkAhead.Business.Models.Parking;

namespace ParkAhead.Business.Profiles
{
	public class ParkingProfile : Profile
	{
        public ParkingProfile()
        {
            CreateMap<ParkingCreateUpdateRequestModel, Data.Entity.Parking>();
            CreateMap<ParkingCreateUpdateRequestModel, ParkingModel>();
            CreateMap<Data.Entity.Parking, ParkingModel>();
        }
    }
}
