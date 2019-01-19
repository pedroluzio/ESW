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

        public string Coordinates { get; set; }

        public List<Appointment> Appointments { get; set; }
        public List<Animal> Animals { get; set; }

        public Boolean CanDelete()
        {
            if ((Animals is null || Animals.Count==0) && (Appointments is null || Appointments.Count==0))
                return true;
            return false;
        }

        public string GetLatitude()
        {
            return Coordinates.Split(',')[0].Substring(1);
        }

        public string GetLongitude()
        {
            return Coordinates.Split(',')[1].Substring(1).Replace(')', ' ');
        }
    }
}
