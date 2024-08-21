namespace ParkAhead.Business.Interfaces
{
	public interface IHashService
	{
		public string CreateSalt();
		public string CreateSaltedPassword(string hashedPassword, string salt);
	}
}
