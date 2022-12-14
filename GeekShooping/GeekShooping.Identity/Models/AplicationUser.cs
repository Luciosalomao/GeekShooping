using Microsoft.AspNetCore.Identity;

namespace GeekShooping.Identity.Models
{
    public class AplicationUser : IdentityUser
    {
        public string nome { get; set; }
        public string sobrenome { get; set; }
    }
}
