using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Core.DomainModels
{
    public class AuthenticateRequest
    {
        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
