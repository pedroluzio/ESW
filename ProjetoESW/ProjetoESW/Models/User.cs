using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Name { get; set; }

    }
}
