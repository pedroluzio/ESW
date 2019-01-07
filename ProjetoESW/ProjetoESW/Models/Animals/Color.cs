using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models.Animals
{
    public class Color
    {
        public int ID { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}
