using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Mappings
{
    public class ComandaMercaderiaMappings : IEntityTypeConfiguration<ComandaMercaderia>
    {
        public void Configure(EntityTypeBuilder<ComandaMercaderia> entityBuilder)
        {
            entityBuilder.ToTable("ComandaMercaderia");
            entityBuilder.HasKey(cm => cm.ComandaMercaderiaId);

            entityBuilder
                .HasOne(cm => cm.Comanda)
                .WithMany(c => c.ComandaMercaderia)
                .IsRequired();

            entityBuilder.Property(p => p.ComandaMercaderiaId).ValueGeneratedOnAdd().IsRequired();
            entityBuilder.Property(p => p.MercaderiaId).IsRequired();
            entityBuilder.Property(p => p.ComandaId).IsRequired();
        }
    }
}
