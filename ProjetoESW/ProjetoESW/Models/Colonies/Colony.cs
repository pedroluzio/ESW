using ProjetoESW.Models.Animals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models.Colonies
{
    public class Colony
    {
        public int ID { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Localização")]
        public string Location { get; set; }

        [Display(Name = "Coordenadas")]
        public string Coordinates { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
