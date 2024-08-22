using AutoMapper;
using ParkAhead.Business.Models.User;

namespace ParkAhead.Business.Profiles
{
	public class UserProfile : Profile
	{
        public UserProfile()
        {
            CreateMap<Data.Entity.User, UserLoginModel>();
            CreateMap<Data.Entity.User, UserModel>();
            CreateMap<UserLoginModel, Data.Entity.User>();
            CreateMap<UserRegistrationModel, UserModel>();
            CreateMap<UserLoginModel, UserModel>();
        }
    }
}
