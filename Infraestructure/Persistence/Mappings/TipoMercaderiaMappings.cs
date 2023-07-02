﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Mappings
{
    public class TipoMercaderiaMappings : IEntityTypeConfiguration<TipoMercaderia>
    {
        public void Configure(EntityTypeBuilder<TipoMercaderia> entityBuilder)
        {
            entityBuilder.ToTable("TipoMercaderia");
            entityBuilder.HasKey(tm => tm.TipoMercaderiaId);

            entityBuilder
                .HasMany(tm => tm.Mercaderia)
                .WithOne(m => m.TipoMercaderia);


            //entityBuilder.Property(p => p.TipoMercaderiaId).ValueGeneratedOnAdd().IsRequired();
            entityBuilder.Property(p => p.TipoMercaderiaId).IsRequired();
            entityBuilder.Property(p => p.Descripcion).HasMaxLength(50).HasColumnType("nvarchar").IsRequired();

            entityBuilder.HasData(
                new TipoMercaderia { TipoMercaderiaId = 1 ,Descripcion = "Entrada" },
                new TipoMercaderia { TipoMercaderiaId = 2, Descripcion = "Minutas" },
                new TipoMercaderia { TipoMercaderiaId = 3, Descripcion = "Pastas" },
                new TipoMercaderia { TipoMercaderiaId = 4, Descripcion = "Parrilla" },
                new TipoMercaderia { TipoMercaderiaId = 5, Descripcion = "Pizzas" },
                new TipoMercaderia { TipoMercaderiaId = 6, Descripcion = "Sandwich" },
                new TipoMercaderia { TipoMercaderiaId = 7, Descripcion = "Ensaladas" },
                new TipoMercaderia { TipoMercaderiaId = 8, Descripcion = "Bebidas" },
                new TipoMercaderia { TipoMercaderiaId = 9, Descripcion = "Cerveza Artesanal" },
                new TipoMercaderia { TipoMercaderiaId = 10, Descripcion = "Postres" }
                );
        }
    }
}
