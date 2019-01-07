using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models.Animals
{
    public class Breed
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Specie Specie { get; set; }

        public List<Animal> Animals { get; set; }
    }
}
