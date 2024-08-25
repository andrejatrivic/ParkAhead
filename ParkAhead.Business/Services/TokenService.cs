using Microsoft.AspNetCore.Authentication.BearerToken;
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
			var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]); 

			var tokenHandler = new JwtSecurityTokenHandler();

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, userModel.Username), 
                    new Claim(ClaimTypes.Email, userModel.Email),
					new Claim(ClaimTypes.MobilePhone, userModel.PhoneNumber)
				}),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256) 
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
