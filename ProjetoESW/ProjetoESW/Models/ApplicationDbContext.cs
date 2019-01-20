using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoESW.Models;
using ProjetoESW.Models.Stock;
using ProjetoESW.Models.Animals;
using ProjetoESW.Models.Colonies;

namespace ProjetoESW.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<User, ApplicationRole, string, IdentityUserClaim<string>,
            ApplicationUserRole, IdentityUserLogin<string>,
            IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjetoESW.Models.Volunteer> Volunteer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Volunteer>()
                .Property(e => e.Date_Regist).HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
        

        public DbSet<ProjetoESW.Models.Stock.ItemType> ItemType { get; set; }

        public DbSet<ProjetoESW.Models.Stock.Item> Item { get; set; }

        public DbSet<ProjetoESW.Models.Stock.Movements> Movements { get; set; }

        public DbSet<ProjetoESW.Models.Accounting> Accounting { get; set; }

        public DbSet<ProjetoESW.Models.AccountMovements> AccountMovements { get; set; }

        public DbSet<ProjetoESW.Models.Animals.Specie> Specie { get; set; }

        public DbSet<ProjetoESW.Models.Animals.Breed> Breed { get; set; }

        public DbSet<ProjetoESW.Models.Colonies.Colony> Colony { get; set; }

        public DbSet<ProjetoESW.Models.Animals.Animal> Animal { get; set; }

        public DbSet<ProjetoESW.Models.Animals.Appointment> Appointment { get; set; }
        
    }
}