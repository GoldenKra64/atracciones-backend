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
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("RESERVA");

            builder.HasKey(x => x.ResId);

            builder.Property(x => x.ResTotal)
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.ResEstado)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.CliId);

            builder.HasMany(x => x.Detalles)
                .WithOne(d => d.Reserva)
                .HasForeignKey(d => d.ResId);

            // 🔥 1:1 con Factura
            builder.HasOne(x => x.Factura)
                .WithOne(f => f.Reserva)
                .HasForeignKey<Factura>(f => f.RevId);
        }
    }
}
