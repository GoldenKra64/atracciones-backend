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
            builder.ToTable("RESERVAS");

            // 🔑 PK
            builder.HasKey(e => e.ResId);

            // 🔗 Columnas
            builder.Property(e => e.ResId).HasColumnName("rev_id");
            builder.Property(e => e.ResGuid).HasColumnName("rev_guid");

            builder.Property(e => e.ResCodigo)
                   .HasColumnName("rev_codigo")
                   .HasMaxLength(20);

            builder.Property(e => e.CliId).HasColumnName("cli_id");

            builder.Property(e => e.ResFechaReservaUtc)
                   .HasColumnName("rev_fecha_reserva_utc");

            builder.Property(e => e.ResSubtotal)
                   .HasColumnName("rev_subtotal");

            builder.Property(e => e.ResValorIva)
                   .HasColumnName("rev_valor_iva");

            builder.Property(e => e.ResTotal)
                   .HasColumnName("rev_total");

            builder.Property(e => e.ResOrigenCanal)
                   .HasColumnName("rev_origen_canal")
                   .HasMaxLength(50);

            builder.Property(e => e.ResUsuarioIngreso)
                   .HasColumnName("rev_usuario_ingreso")
                   .HasMaxLength(100);

            builder.Property(e => e.ResIpIngreso)
                   .HasColumnName("rev_ip_ingreso")
                   .HasMaxLength(45);

            builder.Property(e => e.ResFechaMod)
                   .HasColumnName("rev_fecha_mod");

            builder.Property(e => e.ResUsuarioMod)
                   .HasColumnName("rev_usuario_mod")
                   .HasMaxLength(100);

            builder.Property(e => e.ResIpMod)
                   .HasColumnName("rev_ip_mod")
                   .HasMaxLength(45);

            builder.Property(e => e.ResFechaCancelacion)
                   .HasColumnName("rev_fecha_cancelacion");

            builder.Property(e => e.ResUsuarioCancelacion)
                   .HasColumnName("rev_usuario_cancelacion")
                   .HasMaxLength(100);

            builder.Property(e => e.ResIpCancelacion)
                   .HasColumnName("rev_ip_cancelacion")
                   .HasMaxLength(45);

            builder.Property(e => e.ResMotivoCancelacion)
                   .HasColumnName("rev_motivo_cancelacion")
                   .HasMaxLength(300);

            builder.Property(e => e.ResEstado)
                   .HasColumnName("rev_estado")
                   .HasMaxLength(3);

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
