using System;
using System.Threading.Tasks;
using TravelPlanner.Core;
using TravelPlanner.Core.Exceptions;
using TravelPlanner.Repositories;

namespace TravelPlanner.Services
{
    public interface IUserService
    {
        Task RegisterUser(User user);
        Task<User> GetUser(string login, string password);
    }

    public class UserService : IUserService
    {
        private UserRepository UserRepository;

        public UserService()
        {
            UserRepository = new UserRepository();
        }

        public async Task RegisterUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await UserRepository.RegisterUser(user);
        }

        public async Task<User> GetUser(string mail, string password)
        {
            var responseUser = await UserRepository.GetUser(mail);
            if(!BCrypt.Net.BCrypt.Verify(password, responseUser.Password))
                throw new TravelPlannerException(403, "Forbidden");
            return responseUser;
        }
    }
}
