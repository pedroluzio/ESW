using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjetoESW.Data;

namespace ProjetoESW.Models
{
    public class DBSeeder
    {
        public static void SeedDB(ApplicationDbContext context)
        {
            seedAccounting(context);
        }

        private static void seedAccounting(ApplicationDbContext context)
        {
            if (context.Accounting.Count()<2)
            {
                context.Database.EnsureCreated();
                context.Accounting.Add(
                    new Accounting()
                        {AccountingID = 0, Description = "Banco", Movements = null}
                );
                context.Accounting.Add(
                    new Accounting()
                        {AccountingID = 0, Description = "Caixa", Movements = null}
                );
                context.SaveChanges();
            }
        }
    }
}
