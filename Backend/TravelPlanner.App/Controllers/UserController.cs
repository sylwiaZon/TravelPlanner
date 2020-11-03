using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Core;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        public UserController()
        {
            UserService = new UserService();
        }

        [HttpPost]
        [Route("register")]
        public async Task RegisterUser ([FromBody] User user)
        {
            await UserService.RegisterUser(user);
        }

        [HttpGet]
        public async Task<User> GetUser(string mail, string password)
        {
            return await UserService.GetUser(mail, password);
        }
    }
}
