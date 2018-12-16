using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjetoESW.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual User User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
