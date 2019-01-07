using ProjetoESW.Models.Colonies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models.Animals
{
    public class Animal
    {
        public int ID { get; set; }

        [Display(Name = "Nome")]
        public string Name{ get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Ano de Nascimento")]
        public int YearOfBirth { get; set; }

        [Display(Name = "Sexo")]
        public Gender Gender { get; set; }

        public int BreedID { get; set; }
        [Display(Name = "Raça")]
        public Breed Breed { get; set; }

        public int ColorID { get; set; }
        [Display(Name = "Cor")]
        public Color Color { get; set; }

        [Display(Name = "Data da OVH")]
        public DateTime OVHDate { get; set; }

        public int ColonyID { get; set; }
        [Display(Name = "Colónia")]
        public Colony Colony { get; set; }

        public List<Appointment> Appointments { get; set; }

    }

    public enum Gender
    {
        [Description("Indefinido")] UNDEFINED,
        [Description("Fêmea")] FEMALE,
        [Description("Macho")] MALE
    }
}
