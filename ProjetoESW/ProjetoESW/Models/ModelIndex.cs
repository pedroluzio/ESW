using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoESW.Models;
using ProjetoESW.Models.Stock;
using ProjetoESW.Models.Animals;

namespace ProjetoESW.Models
{
    public class ModelIndex
    {
        public List<ItemType> ItemTypes { get; set; }
        public List<Animal> Animals { get; set; }
        public int NumAnimals { get; set; }
        public int Colonies { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<string> Colors;

        public ModelIndex()
        {
            Colors= new List<string>();
            Colors.Add("#F7464A");
            Colors.Add("#46BFBD");
            Colors.Add("#FDB45C");
            Colors.Add("#949FB1");
            Colors.Add("#4D5360");
        }

        public List<ItemType> LowStock()
        {
            return ItemTypes.Where(i => i.StockAvailable() == "Abaixo do Limite").ToList();
        }
        public List<ItemType> MediumStock()
        {
            return ItemTypes.Where(i => i.StockAvailable() == "Próximo do Limite").ToList();
        }
        public List<ItemType> GoodStock()
        {
            return ItemTypes.Where(i => i.StockAvailable() == "Bom Stock").ToList();
        }

        public int NumMales()
        {
            return Animals.Where(i => i.Gender == Gender.Macho).Count();
        }
        public int NumFemales()
        {
            return Animals.Where(i => i.Gender == Gender.Fêmea).Count();
        }
        public int NumUndefined()
        {
            return Animals.Where(i => i.Gender == Gender.Indefinido).Count();
        }

        /// <summary>Gets the sotcks Names.</summary>
        /// <returns>Return the name of stocks to use in chart</returns>
        public string getStockNames()
        {
            if (ItemTypes is null)
                return "";

            string str = " ";
            foreach (var item in ItemTypes)
            {
                str += "'" + item.Description + "',";
            }

            str = str.Substring(0, str.Length - 1);
            return str;
        }

        /// <summary>Gets the sotcks Units.</summary>
        /// <returns>Return the units of stocks to use in chart</returns>
        public string getStockUnits()
        {
            if (ItemTypes is null)
                return "";

            string str = " ";
            foreach (var item in ItemTypes)
            {
                str += item.QuantityAvailable() + ",";
            }

            str = str.Substring(0, str.Length - 1);
            return str;
        }

        /// <summary>Gets the Colors to the Charts.</summary>
        /// <returns>Return the colors to use in chart</returns>
        public string getColors(int num)
        {
            
            string str = " ";
            for(int i=0 ; i<= num; i++)
            {
                str += "'"+ Colors[i] + "',";
            }

            str = str.Substring(0, str.Length - 1);
            return str;
        }


    }
}
