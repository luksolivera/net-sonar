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
    public class MercaderiaMappings : IEntityTypeConfiguration<Mercaderia>
    {
        public void Configure(EntityTypeBuilder<Mercaderia> entityBuilder)
        {
            entityBuilder.ToTable("Mercaderia");
            entityBuilder.HasKey(m => m.MercaderiaId);
            entityBuilder.HasMany(m => m.ComandaMercaderia).WithOne(cm => cm.Mercaderia).IsRequired();

            entityBuilder.Property(p => p.MercaderiaId).ValueGeneratedOnAdd().IsRequired();
            entityBuilder.Property(p => p.Nombre).HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
            entityBuilder.Property(p => p.Ingredientes).HasMaxLength(255).HasColumnType("nvarchar").IsRequired();
            entityBuilder.Property(p => p.Preparacion).HasMaxLength(255).HasColumnType("nvarchar").IsRequired();
            entityBuilder.Property(p => p.Imagen).HasMaxLength(255).HasColumnType("nvarchar").IsRequired();
            entityBuilder.Property(p => p.TipoMercaderiaId).IsRequired();
            entityBuilder.Property(p => p.Precio).IsRequired();

            entityBuilder.HasData
                (
                    new Mercaderia { MercaderiaId = 1, TipoMercaderiaId = 1, Nombre = "Dip de mostaza y ciboulette", Precio = 600, Ingredientes = "2 Tostadas, 1 dip de mostaza y ciboulette", Preparacion = "Mezclar mostaza y ciboulette", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 2, TipoMercaderiaId = 1, Nombre = "Empanada de carne", Precio = 320, Ingredientes = "Carne, Cebolla, Huevo, Masa casera, Tomate", Preparacion = "Se saltea la cebolla, luego se agrega la carne junto al tomate y se cocina por 10 minutos, se agregan especias y el huevo. Se arma la empanada y se repulga. Luego se cocinan hasta estar bien doradas.", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 3, TipoMercaderiaId = 2, Nombre = "Milanesa a la napolitana", Precio = 1400, Ingredientes = "Milanesa, queso muzzarela, salsa de tomate y oregano", Preparacion = "La milanesa se cubre con salsa de tomate, queso y oregano, y se hornea para que el queso se derrita", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 4, TipoMercaderiaId = 2, Nombre = "Choripan", Precio = 1000, Ingredientes = "Chorizo, pan y salsa a eleccion", Preparacion = "Se hace el chorizo a la parrilla y luego se hace un sandwich con este", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 5, TipoMercaderiaId = 3, Nombre = "Ñoquis de papa", Precio = 1200, Ingredientes = "Ñoquis de papa, salsa filetto", Preparacion = "Se cocinan los ñoquis por alrededor de 3 o 4 minutos y luego se le agrega la salsa", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 6, TipoMercaderiaId = 3, Nombre = "Sorrentinos de jamón y queso", Precio = 1800, Ingredientes = "Jamon, queso y riccota, masa de sorrentinos", Preparacion = "Se rellena la masa con jamon, queso y ricotta. Luego se cocina por 8-10 minutos aprox ", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 7, TipoMercaderiaId = 4, Nombre = "Asado", Precio = 2000, Ingredientes = "Diferentes cortes de carne, como tira de asado, vacío, matambre, chorizo y morcilla", Preparacion = "Sazonados con sal, los cortes de carne se cocinan a fuego lento en la parrilla", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 8, TipoMercaderiaId = 4, Nombre = "Bife de Chorizo", Precio = 600, Ingredientes = "Bife de chorizo", Preparacion = "El bife de chorizo se cocina a la parrilla, a fuego medio, para que quede jugoso y tierno", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 9, TipoMercaderiaId = 5, Nombre = "Pizza de mozzarella", Precio = 1500, Ingredientes = "Harina, agua, sal, aceite, Salsa de tomate, Mozzarella", Preparacion = "Se prepara la masa de pizza. Se deje elevar. Se estira la masa en las pizzeras, luego se agrega la salsa, metemos al horno unos minutos. Luego se agrega la mozzarella y se cocina al horno a 220 °C durante 15 min", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 10, TipoMercaderiaId = 5, Nombre = "Fuggazzeta rellena", Precio = 3400, Ingredientes = "Harina, agua, sal, aceite, cebolla, jamon y mozzarella", Preparacion = "Preparar la masa, armar la fugazzetta y hornear la fugazzetta", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 11, TipoMercaderiaId = 6, Nombre = "Sandwich de milanesa de pollo", Precio = 1000, Ingredientes = "Milanesa de pollo, pan ", Preparacion = "Se cocina la milanesa y luego se le agrega el pan", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 12, TipoMercaderiaId = 6, Nombre = "Sandwich de miga de jamon y queso", Precio = 400, Ingredientes = "Jamon, Queso, Capas de pan de miga blanco sin corteza", Preparacion = "Se rellena el pan con jamon y queso", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 13, TipoMercaderiaId = 7, Nombre = "Ensalada Caesar", Precio = 1200, Ingredientes = "Lechuga romana, pollo a la parrilla, crutones, queso parmesano rallado y aderezo César ", Preparacion = "Mezclar los ingredientes", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 14, TipoMercaderiaId = 7, Nombre = "Ensalada de rúcula", Precio = 1200, Ingredientes = "Base de rúcula, tomates cherry, láminas de parmesano, aceite de oliva y aceto balsámico", Preparacion = "Mezclar los ingredientes", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 15, TipoMercaderiaId = 8, Nombre = "Coca-Cola", Precio = 600, Ingredientes = "Coca-Cola", Preparacion = ".", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 16, TipoMercaderiaId = 8, Nombre = "Fanta", Precio = 600, Ingredientes = "Fanta", Preparacion = ".", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 17, TipoMercaderiaId = 9, Nombre = "Pinta de IPA", Precio = 1000, Ingredientes = "Cerveza Artesanal IPA", Preparacion = ".", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 18, TipoMercaderiaId = 9, Nombre = "Pinta de Honey", Precio = 1000, Ingredientes = "Cerveza Artesanal Honey", Preparacion = ".", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 19, TipoMercaderiaId = 10, Nombre = "Flan Casero", Precio = 1200, Ingredientes = "Huevos, leche y azucar", Preparacion = "Para preparar el flan, se baten los huevos y se mezclan con la leche y el azúcar, y se cuece esta mezcla en un molde con caramelo líquido en baño María. Una vez que se ha enfriado y se ha solidificado, se desmolda y se sirve.", Imagen = "xd" },
                    new Mercaderia { MercaderiaId = 20, TipoMercaderiaId = 10, Nombre = "Chocotorta", Precio = 1500, Ingredientes = "Galletas de chocolate, dulce de leche, queso crema, cafe fuerte", Preparacion = "Preparar la crema, luego armar las capas y por ultimo refrigerar y decorar", Imagen = "xd" }
                );
        }
    }
}
