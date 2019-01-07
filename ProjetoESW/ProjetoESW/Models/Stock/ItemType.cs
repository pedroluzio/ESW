using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models.Stock
{
    public class ItemType
    {
        public int ID { get; set; }

        [Display(Name = "Tipo de Item")]
        public string Description { get; set; }      

        [Display(Name="Limite de Segurança")]
        public decimal SafetyLimit { get; set; }

        public List<Item> Items { get; set; }

        public ItemType(string Description, decimal SafetyLimit)
        {
            this.Description = Description;
            this.SafetyLimit = SafetyLimit;
        }

        /// <summary>Haves the history.</summary>
        /// <returns>
        ///   <para>Return true if have history</para>
        /// </returns>
        public bool HaveHistory()
        {
            if (Items is null)
                return false;
            return Items.Count != 0;
        }

        /// <summary>  Available Quantity</summary>
        /// <returns>Return the Total Available Quantity in Kg</returns>
        public decimal QuantityAvailable()
        {
            if (Items is null)
                return 0;
            return Items.Sum(x => x.Movements.Sum(y => y.Quantity) * x.Quantidade);
        }

        /// <summary>  Available Stock formated</summary>
        /// <returns>Return a formated string with the stock information</returns>
        public string StockAvailable()
        {
            if(QuantityAvailable() < SafetyLimit)
            {
                return "Abaixo do Limite";
            }
            else if (QuantityAvailable() < SafetyLimit* 2)
            {
               return  "Próximo do Limite";
            }
            else
            {
                return "Bom Stock";
            }
        }



        /// <summary>Gets the days history.</summary>
        /// <returns>Return the days of movements to use in chart</returns>
        public string getDaysHistory()
        {
            if (Items is null)
                return "";

            List<Movements> movements = new List<Movements>();
            foreach (var item in Items)
            {
                movements.AddRange(item.Movements);
            }

            Dictionary<DateTime, decimal> allMovements = movements.OrderBy(m => m.Moment).GroupBy(m => m.Moment.Date)
                .ToDictionary(x => x.Key, g => g.Sum(x => x.Quantity * x.Item.Quantidade));

            Dictionary<DateTime, decimal> ListMovements = new Dictionary<DateTime, decimal>();

            foreach (var movement in allMovements)
            {
                ListMovements.Add(movement.Key, allMovements.Where(x => x.Key <= movement.Key).Sum(x => x.Value));
            }

            string str = "";
            foreach (var day in ListMovements.Keys)
            {
                str += "'"+day + "',";
            }

            str = str.Substring(0, str.Length - 1);
            return str;

        }

        /// <summary>Gets the value history.</summary>
        /// <returns>Return the number of movements to use in chart</returns>
        public string getValueHistory()
        {
            if (Items is null)
                return "";
            List<Movements> movements = new List<Movements>();
            foreach (var item in Items)
            {
                movements.AddRange(item.Movements);
            }

            Dictionary<DateTime, decimal> allMovements = movements.OrderBy(m => m.Moment).GroupBy(m => m.Moment.Date)
                .ToDictionary(x => x.Key, g => g.Sum(x => x.Quantity * x.Item.Quantidade));

            Dictionary<DateTime, decimal> ListMovements = new Dictionary<DateTime, decimal>();

            foreach (var movement in allMovements)
            {
                ListMovements.Add(movement.Key, allMovements.Where(x => x.Key <= movement.Key).Sum(x => x.Value));
            }

            string str = "";

            NumberFormatInfo nfi = new NumberFormatInfo {NumberDecimalSeparator = "."};

            foreach (var day in ListMovements.Values)
            {
                str += day.ToString(nfi) + ",";
            }

            str = str.Substring(0, str.Length - 1);
            return str;

        }


    }
}
