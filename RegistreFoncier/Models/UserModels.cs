using Microsoft.AspNet.Identity.EntityFramework;

namespace RegistreFoncier.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string Email { get; set; }
    }
}