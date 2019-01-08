using Microsoft.AspNetCore.Identity;

namespace Core.Web.Models.Entities
{
    public class User : IdentityUser
    {
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
    }
}
