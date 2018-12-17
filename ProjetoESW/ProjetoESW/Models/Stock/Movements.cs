using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace ProjetoESW.Models.Stock
{
    public class Movements
    {
        public int ID { get; set; }

        public int ItemID { get; set; }

        public DateTime Moment { get; set; }

        public int Quantity { get; set; }

        public Item Item { get; set; }

       

    }
}
