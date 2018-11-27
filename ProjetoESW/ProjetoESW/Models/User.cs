using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Areas.Identity.Data
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Nome { get; set; }
    }
}
