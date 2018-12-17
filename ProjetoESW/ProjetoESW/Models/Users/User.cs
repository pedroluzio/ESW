using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace ProjetoESW.Models
{
    public class User : IdentityUser
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
