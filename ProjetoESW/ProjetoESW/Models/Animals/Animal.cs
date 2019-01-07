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

        //TODO: Método para dado uma idade aproximada calcular o ano de nascimento

        //TODO: construtor que recebe a data de nascimento e outro que recebe a idade

        //TODO: Ver se tem ovh ou não

        //TODO: ver data de ovh



    }

    public enum Gender
    {
        [Description("Indefinido")] UNDEFINED,
        [Description("Fêmea")] FEMALE,
        [Description("Macho")] MALE
    }
}
