using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models
{
    public class UserRoleList
    {
        public User user { get; set; }
        public IEnumerable<ApplicationRole> roles { get; set; }
    }
}
