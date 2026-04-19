using Atracciones.Backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Configurations
{
    public class AtraccionConfiguration : IEntityTypeConfiguration<Atraccion>
    {
        public void Configure(EntityTypeBuilder<Atraccion> builder)
        {
            builder.ToTable("ATRACCION");

            builder.HasKey(x => x.AtId);

            builder.Property(x => x.AtNombre)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.AtDescripcion)
                .HasMaxLength(2000);

            builder.Property(x => x.AtDireccion)
                .HasMaxLength(300);

            builder.Property(x => x.AtPuntoEncuentro)
                .HasMaxLength(300);

            builder.Property(x => x.AtPrecioReferencia)
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.AtEstado)
                .IsRequired()
                .HasMaxLength(20);

            // 🔥 Relación con Destino
            builder.HasOne(x => x.Destino)
                .WithMany(d => d.Atracciones)
                .HasForeignKey(x => x.DesId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔥 Relación con Imagen
            builder.HasMany(x => x.Imagenes)
                .WithOne(i => i.Atraccion)
                .HasForeignKey(i => i.AtId);

            // 🔥 Relación con IncluyeAtracciones (Categoría-Atracción)
            builder.HasMany(x => x.IncluyeAtracciones)
                .WithOne(ia => ia.Atraccion)
                .HasForeignKey(ia => ia.AtId);

            // 🔥 Relación con Idioma
            builder.HasMany(x => x.IdiomaAtracciones)
                .WithOne(ia => ia.Atraccion)
                .HasForeignKey(ia => ia.AtId);
        }
    }
}
