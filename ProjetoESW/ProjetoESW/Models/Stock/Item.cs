using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetoESW.Models.Stock
{
    public class Item
    {
        public int ID { get; set; }

        [Display(Name="Tipo de Item")]
        public int ItemTypeID { get; set; }

        [Display(Name = "Tipo de Item")]
        public ItemType ItemType { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Quantidade em Kg")]
        public decimal Quantidade { get; set; }

        public List<Movements> Movements { get; set; }


        /// <summary>Haves the history.</summary>
        /// <returns>True if have history</returns>
        public bool HaveHistory()
        {
            if (Movements is null)
                return false;
            return Movements.Count != 0;
        }

        /// <summary>Gets the days history.</summary>
        /// <returns>Return the days of movements to use in chart</returns>
        public string getDaysHistory()
        {
            if (Movements is null)
                return "";
            Dictionary<DateTime, int> myMovementes = Movements
                .OrderBy(x => x.Moment)
                .GroupBy(x => x.Moment.Date)
                .ToDictionary(x => x.Key, g => g.Count());

            string str = "";
            foreach (var day in myMovementes.Keys)
            {
                str += "'" + day.ToString("dd/MM/yyyy") + "',";
            }

            str = str.Substring(0, str.Length - 1);
            return str;
        }


        /// <summary>Gets the value history.</summary>
        /// <returns>Return the value of total movements to use in chart</returns>
        public string getValueHistory()
        {
            if (Movements is null)
                return "";
            Dictionary<DateTime, int> myMovementes = Movements
                .OrderBy(x => x.Moment)
                .GroupBy(x => x.Moment.Date)
                .ToDictionary(x => x.Key, g => g.Sum(x=>x.Quantity));

            string str = "";
            foreach (var day in myMovementes.Values)
            {
                str += day + ",";
            }

            str = str.Substring(0, str.Length - 1);
            return str;
        }

        public decimal QuantityAvailable()
        {
            if (Movements is null)
                return 0;
            return Movements.Sum(x => x.Quantity) * Quantidade;
        }
    }
}
