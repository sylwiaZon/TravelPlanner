using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.App.Helpers;
using TravelPlanner.Core;
using TravelPlanner.Core.DomainModels;
using TravelPlanner.Core.Exceptions;
using TravelPlanner.Repositories;

namespace TravelPlanner.Services
{
    public interface IUserService
    {
        Task RegisterUser(User user);
        Task<User> GetUser(string login, string password);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<User> GetByEmail(string email);
    }

    public class UserService : IUserService
    {
        private UserRepository UserRepository;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, DbSettings dbSettings)
        {
            UserRepository = new UserRepository(dbSettings);
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await GetUser(model.Mail, model.Password);

            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task RegisterUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await UserRepository.RegisterUser(user);
        }

        public async Task<User> GetUser(string mail, string password)
        {
            var responseUser = await UserRepository.GetUser(mail);
            if(!(responseUser is null) && !BCrypt.Net.BCrypt.Verify(password, responseUser.Password))
                throw new TravelPlannerException(403, "Forbidden");
            return responseUser;
        }

        public async Task<User> GetByEmail(string mail)
        {
            var responseUser = await UserRepository.GetUser(mail);
            return responseUser;
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Mail", user.Mail.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
