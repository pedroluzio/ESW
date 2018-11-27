using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoESW.Areas.Identity;
using ProjetoESW.Areas.Identity.Data;
using ProjetoESW.Data;

namespace ProjetoESW.Models
{
    public class DBInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            // Look for any Volunteer.
            if (context.Volunteer.Any())
            {
                // A base de dados foi inicializada antes
                return; 
            }

            context.SaveChanges();

            var adminRole = new IdentityRole("Administrator");
            if (!await roleManager.RoleExistsAsync(adminRole.Name))
            {
                await roleManager.CreateAsync(adminRole);
            }

            var assetRole = new IdentityRole("AssetManager");
            if (!await roleManager.RoleExistsAsync(assetRole.Name))
            {
                await roleManager.CreateAsync(assetRole);
            }

            var colonyRole = new IdentityRole("ColonyManager");
            if (!await roleManager.RoleExistsAsync(colonyRole.Name))
            {
                await roleManager.CreateAsync(colonyRole);
            }

            var admin = new User { UserName = "admin", Nome = "Admin", Email="admin@esw.pt" };
            var result = await userManager.CreateAsync(admin, "Abc123!");
        }
    }
}
