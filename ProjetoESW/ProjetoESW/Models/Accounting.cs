﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models
{
    public class Accounting
    {
        public int AccountingID { get; set; }

        [Display(Name="Descrição")]
        public string Description { get; set; }

        public List<AccountMovements> Movements { get; set; }

        public decimal Balance()
        {
            return Movements.Sum(m => m.Ammount);
        }
    }
}
