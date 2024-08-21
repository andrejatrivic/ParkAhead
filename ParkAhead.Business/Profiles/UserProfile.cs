using AutoMapper;
using ParkAhead.Business.Models.User;

namespace ParkAhead.Business.Profiles
{
	public class UserProfile : Profile
	{
        public UserProfile()
        {
            CreateMap<Data.Entity.User, UserModel>();
            CreateMap<UserModel, Data.Entity.User>();
        }
    }
}
