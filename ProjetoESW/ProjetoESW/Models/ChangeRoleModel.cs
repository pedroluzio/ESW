using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models
{
    public class ChangeRoleModel
    {

        public string Email { get; set; }

        public List<IdentityRole> Roles { get; set; }

        public List<User> Users { get; set; }

        public string Rolename { get; set; }
    }
}
