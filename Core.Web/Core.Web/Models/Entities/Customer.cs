using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Web.Models.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(256)]
        public string IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public virtual IdentityUser IdentityUser { get; set; }
        public long? FacebookId { get; set; }
        [MaxLength(256)]
        public string PictureUrl { get; set; }
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        public string LastName { get; set; }
        public string Gender { get; set; }
        [MaxLength(256)]
        public string Location { get; set; }
    }
}
