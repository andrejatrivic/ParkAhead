using AutoMapper;
using Microsoft.Extensions.Configuration;
using ParkAhead.Business.Interfaces;
using ParkAhead.Business.Models.User;
using ParkAhead.Data.Entity;
using ParkAhead.Data.Repository;
using System.Text;

namespace ParkAhead.Business.Services
{
	public class UserService : IUserService
	{
		private const string SUCCESS = "SUCCESS";
		private const string FAILED = "FAILED";

		private readonly IRepository<User> _repository;
		private readonly IHashService _hashService;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;
		public UserService(IRepository<User> repository, IHashService hashService, IMapper mapper, IConfiguration configuration)
		{
			_repository = repository;
			_hashService = hashService;
			_mapper = mapper;
			_configuration = configuration;
		}

		public async Task<string> Login(UserModel loginModel)
		{
			var userEntity = GetUser(loginModel.Username);

			if (userEntity == null)
			{
				return FAILED;
			}

			if (CheckPassword(loginModel.PasswordHash, userEntity.Salt, userEntity.PasswordHash))
			{
				return SUCCESS;
			}

			return FAILED;
		}


		public async Task<string> Registration(UserRegistrationModel registrationModel)
		{
			if (UserExists(registrationModel.Username, registrationModel.Email))
			{
				return FAILED;
			}

			var newUser = CreateUser(registrationModel);

			_repository.Add(newUser);
			await _repository.SaveAsync();

			return SUCCESS;
		}

		private User CreateUser(UserRegistrationModel registrationModel)
		{
			var salt = _hashService.CreateSalt();
			return new User
			{
				Username = registrationModel.Username,
				Email = registrationModel.Email,
				PhoneNumber = registrationModel.PhoneNumber,
				Salt = salt,
				PasswordHash = _hashService.CreateSaltedPassword(registrationModel.PasswordHash, salt)
			};
		}

		private User GetUser(string username)
		{
			var userEntity = _repository.GetAll().Where(x => x.Username == username).FirstOrDefault();
			return userEntity;
		}

		private bool UserExists(string username, string email)
		{
			var userUsername = _repository.GetAll().Where(x => x.Username == username).FirstOrDefault();
			var userEmail = _repository.GetAll().Where(x => x.Email == email).FirstOrDefault();
			if (userUsername is not null || userEmail is not null)
			{
				return true;
			}
			else return false;
		}	
		
		private bool CheckPassword(string hashPass, string storedSalt, string storedHashSaltPass)
		{
			byte[] hashPassBytes = Encoding.UTF8.GetBytes(hashPass);
			byte[] storedSaltBytes = Encoding.UTF8.GetBytes(storedSalt);
			byte[] storedHashSaltPassBytes = Encoding.UTF8.GetBytes(storedHashSaltPass);

			byte[] saltedPasswordBytes = new byte[hashPassBytes.Length + storedSaltBytes.Length];

			hashPassBytes.CopyTo(saltedPasswordBytes, 0);
			storedSaltBytes.CopyTo(saltedPasswordBytes, hashPassBytes.Length);

			return storedHashSaltPassBytes.SequenceEqual(saltedPasswordBytes);
		}
	}
}
