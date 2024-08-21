using ParkAhead.Business.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ParkAhead.Business.Services
{
	public class HashService : IHashService
	{
		public string CreateSalt()
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			Random random = new Random();
			string salt = new string(Enumerable.Repeat(chars, 8)
				.Select(s => s[random.Next(s.Length)]).ToArray());
			return salt;
		}

		public string CreateSaltedPassword(string hashedPassword, string salt)
		{
			byte[] passwordBytes = Encoding.UTF8.GetBytes(hashedPassword);
			byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

			byte[] satedPasswordBytes = new byte[passwordBytes.Length + saltBytes.Length];

			passwordBytes.CopyTo(satedPasswordBytes, 0);
			saltBytes.CopyTo(satedPasswordBytes, passwordBytes.Length);

			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] computedHash = sha256.ComputeHash(satedPasswordBytes);
				return Convert.ToHexString(computedHash).ToLower();
			}
		}
	}
}
