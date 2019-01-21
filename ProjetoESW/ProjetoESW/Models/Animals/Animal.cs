using ProjetoESW.Models.Colonies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

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

        [Display(Name = "Raça")]
        public int BreedID { get; set; }

        [Display(Name="Raça")]
        public Breed Breed { get; set; }


        [Display(Name = "Cor")]
        public String Color { get; set; }
   
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


        public IOrderedEnumerable<Appointment> GetAppointments()
        {
            return Appointments
                .OrderBy(x => x.Date < DateTime.Now)
                .ThenBy(x => x.Date);
        }

        /// <summary>
        /// This methods checks if an animal has OVH.
        /// </summary>
        /// <returns>True if the animal has an OVH, false if not.</returns>
        public bool hasOVH()
        {
            return (OVHDate != null);
        }


        public string GetOVHDate()
        {
            DateTime OVH = Convert.ToDateTime(OVHDate);
            if (hasOVH())
                return OVH.ToString("dd-MM-yyyy");
            return "";
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

        public Boolean HaveHistory()
        {
            if (Appointments is null)
                return false;
            return Appointments.Count != 0;
        }

        public string Age()
        {
            DateTime Birth = Convert.ToDateTime(Birthdate);
            if (!(Birthdate is null))
            {
                int years = DateTime.Now.Year - Birth.Year;
                if ((Birth.Month > DateTime.Now.Month) || (Birth.Month == DateTime.Now.Month && Birth.Day > DateTime.Now.Day))
                    years--;

                if (years == 0)
                {
                    int months = (DateTime.Now.Year> Birth.Year? 12+DateTime.Now.Month - Birth.Month: DateTime.Now.Month - Birth.Month);
                    if (months == 0)
                        return DateTime.Now.Day - Birth.Day + " Dias";
                    return months + " Meses";
                }


                return years + " Anos";
            }

                return "+/- " + (DateTime.Now.Year - Convert.ToInt32(YearOfBirth)) + " Anos";


        }

        public string[] getBirthdayDetaisl()
        {
            if (!(Birthdate is null))
            {
                DateTime Birth = Convert.ToDateTime(Birthdate);
                return new string[] {"Data de Nascimento:", Birth.ToString("dd-MM-yyyy")};
            }

            return new string[]{"Ano Aproximado de Nascimento:",YearOfBirth.ToString()};

        }
    }

    public enum Gender
    {
        Indefinido, Fêmea, Macho
    }
}
