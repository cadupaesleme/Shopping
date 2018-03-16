using Saphyr.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Saphyr.Context
{
    public class SaphyrContext : DbContext
    {
        public DbSet<Shopping> Shoppings { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Loja> Lojas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            //retirar deletar em cascata
            modelBuilder.Entity<Shopping>()
            .HasOptional(s => s.Gerente)
            .WithMany()
            .WillCascadeOnDelete(false);


        }
    }
}
