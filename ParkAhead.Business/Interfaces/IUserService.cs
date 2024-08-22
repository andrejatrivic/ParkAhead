using ParkAhead.Business.Models.User;

namespace ParkAhead.Business.Interfaces
{
	public interface IUserService
	{
		Task<string> Login(UserLoginModel loginModel);
		Task<string> Registration(UserRegistrationModel registrationModel);
	}
}
