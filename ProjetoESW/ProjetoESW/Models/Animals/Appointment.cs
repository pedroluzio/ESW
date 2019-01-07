using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjetoESW.Models.Colony;

namespace ProjetoESW.Models.Animals
{
    public class Appointment
    {
        public int ID { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Display(Name = "Nota")]
        public string Note { get; set; }

        public int AnimalID { get; set; }
        [Display(Name = "Animal")]
        public Animal Animal { get; set; }

        public int OVHID { get; set; }
        public OVH OVH { get; set; }

        public int ColonyID { get; set; }
        public Colony Colony { get; set; }
    }
}
