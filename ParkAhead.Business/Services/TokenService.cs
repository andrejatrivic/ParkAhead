using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ParkAhead.Business.Interfaces;
using ParkAhead.Business.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParkAhead.Business.Services
{
	public class TokenService : ITokenService
	{
		private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
			_configuration = configuration;
        }

        public string CreateToken(UserModel userModel)
		{
			var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

			var tokenHandler = new JwtSecurityTokenHandler();

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
				new Claim("username", userModel.Username),
				new Claim("email", userModel.Email),
				new Claim("phoneNumber", userModel.PhoneNumber)
				}),
				Expires = DateTime.UtcNow.AddHours(1)	
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
