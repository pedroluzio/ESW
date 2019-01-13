using ProjetoESW.Models.Colonies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
        public DateTime? Birthdate { get; set; }

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
        public DateTime? OVHDate { get; set; }

        public int? ColonyID { get; set; }
        [Display(Name = "Colónia")]
        public Colony Colony { get; set; }

        public List<Appointment> Appointments { get; set; }

        /// <summary>
        /// This method calculates the year of birth by the given age.
        /// </summary>
        /// <param name="idade">The age to calculate year.</param>
        /// <returns>The estimated year of birth.</returns>
        public int CalcularAno(int idade)
        {
            return DateTime.Now.Year - idade;
        } 

        /// <summary>
        /// This methods checks if an animal has OVH.
        /// </summary>
        /// <returns>True if the animal has an OVH, false if not.</returns>
        public bool hasOVH()
        {
            return (OVHDate != null);
        }

        /// <summary>
        /// This method returns the OVH date in dd/M/yyyy format.
        /// </summary>
        /// <returns>A string with the OVH date in dd/M/yyyy format</returns>
        /*public string OVHDateString()
        {
            return OVHDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        }*/

        /// <summary>
        /// This method returns the note associated with the animal OVH.
        /// </summary>
        /// <returns>A string with the note associated with the animal OVH.</returns>
        public string OVHNotes()
        {
            foreach(Appointment appointment in Appointments)
            {
                if (appointment.OVH && OVHDate.Equals(appointment.Date))
                    return appointment.Note;
            }
            return "";
        }
    }

    public enum Gender
    {
        [Description("Indefinido")] UNDEFINED,
        [Description("Fêmea")] FEMALE,
        [Description("Macho")] MALE
    }
}
