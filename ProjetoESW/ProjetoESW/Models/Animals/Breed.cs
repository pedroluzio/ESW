using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models.Animals
{
    public class Breed
    {
        public int ID { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome da Raça é obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Espécie")]
        public int SpecieID { get; set; }
        public Specie Specie { get; set; }

        public List<Animal> Animals { get; set; }
    }
}
