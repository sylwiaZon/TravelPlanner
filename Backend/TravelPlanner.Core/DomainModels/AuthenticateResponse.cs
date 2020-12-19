using System;
using System.Collections.Generic;
using System.Text;

namespace TravelPlanner.Core.DomainModels
{
    public class AuthenticateResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse()
        {
        }

        public AuthenticateResponse(User user, string token)
        {
            Name = user.Name;
            Token = token;
        }
    }
}
