using Microsoft.AspNetCore.Identity;

namespace Core.Web.Models.Entities.Dto.Request
{
    public class UserRegisterRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
