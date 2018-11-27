using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models
{
    public class Volunteer
    {
        public int ID { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Num. Telemóvel")]
        public string Telephone { get; set; }

        public DateTime? Date_Regist { get; set; }




    }


}
