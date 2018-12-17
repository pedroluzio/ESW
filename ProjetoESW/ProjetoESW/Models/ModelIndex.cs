using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoESW.Models.Stock;

namespace ProjetoESW.Models
{
    public class ModelIndex
    {
        public List<ItemType> ItemTypes { get; set; }

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
    }
}
