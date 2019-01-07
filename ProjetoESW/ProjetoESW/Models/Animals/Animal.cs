using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models.Animals
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name{ get; set; }
        public DateTime Birthdate { get; set; }
        public int YearOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Breed Breed { get; set; }
        public Color Color { get; set; }
        
    }

    public enum Gender
    {
        [Description("Indefinido")] UNDEFINED,
        [Description("Fêmea")] FEMALE,
        [Description("Macho")] MALE
    }
}
