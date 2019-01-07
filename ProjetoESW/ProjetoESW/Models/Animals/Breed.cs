using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models.Animals
{
    public class Breed
    {
        public int ID { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        public int SpecieID { get; set; }
        [Display(Name = "Espécie")]
        public Specie Specie { get; set; }

        public List<Animal> Animals { get; set; }
    }
}
