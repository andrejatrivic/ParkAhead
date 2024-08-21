using ParkAhead.Business.Models.User;

namespace ParkAhead.Business.Interfaces
{
	public interface IUserService
	{
		Task<string> Login(UserModel loginModel);
		Task<string> Registration(UserRegistrationModel registrationModel);
	}
}
