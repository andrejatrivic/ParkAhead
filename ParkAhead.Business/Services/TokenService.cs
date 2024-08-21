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
			List<Claim> claims = new()
			{
				new Claim("username", userModel.Username),
				new Claim("email", userModel.Email),
				new Claim("phoneNumber", userModel.PhoneNumber)
			};

			//var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
			//var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
			//var token = new JwtSecurityToken(
			//	claims: claims,
			//	expires: DateTime.Now.AddDays(1),
			//	signingCredentials: creds
			//);
			//var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			//return jwt;

			throw new NotImplementedException();
		}
	}
}
