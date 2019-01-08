using Microsoft.AspNetCore.Identity;

namespace Core.Web.Models.Dto.Request
{
    public class UserRegisterRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
