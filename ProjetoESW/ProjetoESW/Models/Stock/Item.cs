using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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


        public bool HaveHistory()
        {
            return Movements.Count != 0;
        }
    }
}
