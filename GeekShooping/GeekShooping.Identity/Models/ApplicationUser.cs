using Microsoft.AspNetCore.Identity;

namespace GeekShooping.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
    }
}
