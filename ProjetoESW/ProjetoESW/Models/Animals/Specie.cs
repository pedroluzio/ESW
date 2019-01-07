using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models.Animals
{
    public class Specie
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Breed> Breeds { get; set; }
    }
}
