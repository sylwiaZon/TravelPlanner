

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelPlanner.Tests.Unit.Controllers
{
    public static class ControllersUtils
    {
        public static void SetupDefaultContextWithUser(this ControllerBase controller, string username)
        {
            controller.SetupDefaultContext(new Dictionary<object, object>
            {
                { "User", username }
            });
        }
        
        public static void SetupDefaultContext(this ControllerBase controller, Dictionary<object, object> items)
        {
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Items = items
                }
            };
        }
    }
}