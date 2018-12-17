using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoESW.Areas.Identity;
using ProjetoESW.Data;

namespace ProjetoESW.Models
{
    public class DBInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<User> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            var adminRole = new ApplicationRole("Administrator");
            if (!await roleManager.RoleExistsAsync(adminRole.Name))
            {
                await roleManager.CreateAsync(adminRole);
            }

            var stocksRole = new ApplicationRole("Gestor de Stocks");
            if (!await roleManager.RoleExistsAsync(stocksRole.Name))
            {
                await roleManager.CreateAsync(stocksRole);
            }


            var RHRole = new ApplicationRole("Gestor de RH");
            if (!await roleManager.RoleExistsAsync(RHRole.Name))
            {
                await roleManager.CreateAsync(RHRole);
            }

            var financeiroRole = new ApplicationRole("Gestor Financeiro");
            if (!await roleManager.RoleExistsAsync(financeiroRole.Name))
            {
                await roleManager.CreateAsync(financeiroRole);
            }

            var admin = new User { UserName = "admin@esw.pt", Email = "admin@esw.pt" };
            await userManager.CreateAsync(admin, "Abc123!");

            await userManager.AddToRoleAsync(admin, adminRole.Name);
        }
    }
}