using ParkAhead.Business.Models.User;

namespace ParkAhead.Business.Interfaces
{
	public interface ITokenService
	{
		public string CreateToken(UserModel userLoginModel);
	}
}
