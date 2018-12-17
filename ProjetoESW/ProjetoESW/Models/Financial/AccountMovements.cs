using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Models
{
    public class AccountMovements
    {
        public int AccountMovementsID { get; set; }
        public int AccountingID { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Valor")]
        public decimal Ammount { get; set; }

        [Display(Name = "Conta")]
        public Accounting Accounting { get; set; }
    }
}
