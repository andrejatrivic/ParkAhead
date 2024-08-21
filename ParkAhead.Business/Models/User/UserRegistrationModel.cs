namespace ParkAhead.Business.Models.User
{
	public class UserRegistrationModel
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string PasswordHash { get; set; }
	}
}
