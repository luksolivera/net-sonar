using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infraestructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Infraestructure.Persistence
{
    public class AppDbcontext : DbContext
    {
        public DbSet<Mercaderia> Mercaderia { get; set; }
        public DbSet<TipoMercaderia> TipoMercaderia { get; set; }
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<ComandaMercaderia> ComandaMercaderia { get; set; }
        public DbSet<FormaEntrega> FormaEntrega { get; set; }


        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=Corsiglia;User Id=sa;Password=Admin#1234;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbcontext).Assembly);
        }

    }
}


 