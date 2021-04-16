using System.ComponentModel.DataAnnotations;

namespace ProjectServer.Core.Models.DTOs.Requests
{
    public class UserLoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
