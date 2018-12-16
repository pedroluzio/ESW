using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public bool HaveHistory()
        {
            return Items.Count != 0;
        }
    }
}
